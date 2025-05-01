using External.Authentication.Twilio;
using GroceryWebApp.Pages.Basket.Services;
using GroceryWebApp.Pages.Login.Model;
using GroceryWebApp.Pages.Login.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Verify.V2;
using Twilio.Rest.Verify.V2.Service;

namespace GroceryWebApp.Controllers.Login
{
    public class UserLoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ISmsSender _smsSender;
        private readonly ILogger<UserLoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketService _basketService;
        public UserLoginController(ILoginService loginService, IConfiguration configuration,
            ISmsSender smsSender, IHttpContextAccessor httpContextAccessor, IBasketService basketService,
            ILogger<UserLoginController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _smsSender = smsSender ?? throw new ArgumentNullException(nameof(smsSender));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [HttpGet(Name = "VerifyUser")]
        public async Task<IActionResult> VerifyUser(string mobile)
        {
            //var user = await GetUser(mobile) as User; //returning value from Action to Action thats why data is coming null
            var user = await _loginService.GetUser(mobile);
            if (user != null)
            {
                await _smsSender.GetSMSCodeAsync(mobile);
                return PartialView("~/Pages/Login/UI/Partial/_UserRegCodeVerify.cshtml");
            }

            _logger.LogInformation("User Has enrolled");
            return Json("1");
        }

        [HttpGet(Name = "GenerateToken")]
        public async Task<IActionResult> GenerateToken(string mobile)
        {
            if (_httpContextAccessor.HttpContext.Session != null &&
                    _httpContextAccessor.HttpContext.Session.IsAvailable &&
                        _httpContextAccessor.HttpContext.Session.Keys.Contains("UserId"))
            {
                return Ok(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
            }

            var user = await _loginService.GetUser(mobile);

            if (user == null) return null; //No User Found

            var userRoles = await _loginService.GetUserRoles(mobile);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                        new Claim(JwtRegisteredClaimNames.Name, user.Mobile),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(20),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role.RoleName)));
            tokenDescriptor.Subject.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                _httpContextAccessor.HttpContext.Session.SetString("JWToken", stringToken);
                _httpContextAccessor.HttpContext.Session.SetInt32("UserAdmin", userRoles.ToList().Where(r => r.RoleName == "Admin").Select(c => c.RoleName).ToList().Count);
                // var res = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
                var refreshToken = new UserToken() { UserName = user.Id.ToString(), RefreshToken = GenerateRefreshToken() };
                _httpContextAccessor.HttpContext.Session.SetString("RefreshToken", refreshToken.RefreshToken);

                if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    var cookieuserid = _httpContextAccessor.HttpContext.Request.Cookies["UserId"].ToString();
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserId");
                    CookieOptions option = new CookieOptions();
                    //option.Expires = DateTime.Now.AddMinutes(100);
                    option.HttpOnly = true;
                    option.SameSite = SameSiteMode.Strict;
                    option.Domain = "localhost";
                    HttpContext.Response.Cookies.Append("UserId", user.Id.ToString(), option);
                    await _basketService.UpdateBasketUserId(new Pages.Basket.Model.BasketUserIdUpdate() { UserGUId = cookieuserid, UserId = user.Id.ToString() });
                }


                await _loginService.AddUserRefreshTokens(refreshToken);
                return Ok(stringToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // return Unauthorized();
        }

        [HttpPost(Name = "Refresh")]
        public async Task<IActionResult> Refresh()
        {
            var username = HttpContext.User?.Claims.Where(c => c.Type.ToLower() == "id").Select(s => s.Value).FirstOrDefault<string>();
            var usermobile = HttpContext.User?.Claims.Where(c => c.Type.ToLower() == "name").Select(s => s.Value).FirstOrDefault<string>();
            var refreshtoken = _httpContextAccessor.HttpContext.Session.GetString("RefreshToken");
            //retrieve the saved refresh token from database
            var savedRefreshToken = await _loginService.GetSavedRefreshTokens(new UserToken() { UserName = username, RefreshToken = refreshtoken });

            if (savedRefreshToken.RefreshToken != refreshtoken)
            {
                return Unauthorized("Invalid attempt!");
            }

            var newJwtToken = GenerateToken(usermobile);

            if (newJwtToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            // saving refresh token to the db
            UserToken obj = new UserToken
            {
                RefreshToken = _httpContextAccessor.HttpContext.Session.GetString("RefreshToken"),
                UserName = username
            };

            await _loginService.DeleteUserRefreshTokens(savedRefreshToken);

            return Ok(newJwtToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        [HttpGet(Name = "VerifySMS")]
        public async Task<IActionResult> VerifySMS(string mobile, string code)
        {

            var status = await _smsSender.VerifySMSCodeAsync(mobile, code);


            return Json(status);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var Users = await _loginService.GetUsers();
            // var UsersList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            _logger.LogInformation("User Info Pulled");
            return Json(Users);
        }
        [HttpGet(Name = "GetUser/{mobile}")]
        public async Task<IActionResult> GetUser(string mobile)
        {
            var user = await _loginService.GetUser(mobile);
            _logger.LogInformation("User Info Pulled");
            return Json(user);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User model)
        {
            var res = await _loginService.CreateUser(model);
            _logger.LogInformation("Usr Created Successfully");
            return Ok(res);
        }

        [HttpGet(Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            var username = HttpContext.User?.Claims.Where(c => c.Type.ToLower() == "id").Select(s => s.Value).FirstOrDefault<string>();
            var refreshtoken = HttpContext.Session.GetString("RefreshToken");
            await _loginService.DeleteUserRefreshTokens(new GroceryWebApp.Pages.Login.Model.UserToken() { UserName = username, RefreshToken = refreshtoken });

            HttpContext.User = null;
            HttpContext.Session.Clear();
            HttpContext.Session = null;
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            if (HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                HttpContext.Response.Cookies.Delete("UserId");
            }

            return Ok("LoggedOut");
        }
    }
}
