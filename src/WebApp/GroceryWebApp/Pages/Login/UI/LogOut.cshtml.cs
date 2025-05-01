using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Login.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GroceryWebApp.Pages.Login.UI
{
    public class LogOutModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LogOutModel> _logger;
        private readonly ILoginService _loginService;
        public LogOutModel(ILoginService loginService, IHttpContextAccessor httpContextAccessor, ILogger<LogOutModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }


        public async Task OnGetAsync()
        {

            var username = HttpContext.User?.Claims.Where(c => c.Type.ToLower() == "id").Select(s => s.Value).FirstOrDefault<string>();
            var refreshtoken = HttpContext.Session.GetString("RefreshToken");
            await _loginService.DeleteUserRefreshTokens(new Model.UserToken() { UserName = username, RefreshToken = refreshtoken });

            var claimNameList = HttpContext.User.Claims.Select(x => x.Type).ToList();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var t = HttpContext.User.Identities.FirstOrDefault();
            foreach (var name in claimNameList)
            {
                var claim = identity.Claims.FirstOrDefault(x => x.Type == name);
                if (claim != null) identity.RemoveClaim(claim);
            }
            
            HttpContext.User.Claims.ToList().Clear();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Clear();
            HttpContext.Session = null;
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
           // HttpContext.Items.Clear();
            
        }
    }
}
