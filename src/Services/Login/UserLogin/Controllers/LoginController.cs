using Login.Application.Features.Commands.CreateUser;
using Login.Application.Features.Login.Query.GetUser;
using Login.Application.Features.Login.Query.GetUserRole;
using Login.Application.Features.Tokens.Add;
using Login.Application.Features.Tokens.Delete;
using Login.Application.Features.Tokens.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Login.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<GetUserList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetUserList>>> GetUsers()
        {
            var query = new GetUserCommand();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUser/{mobile}")]
        [ProducesResponseType(typeof(IEnumerable<GetUserList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetUserList>>> GetUser(string mobile)
        {
            var query = new GetUserCommand(mobile);
            var user = await _mediator.Send(query);
            return Ok(user.FirstOrDefault<GetUserList>());
        }

        [HttpGet]
        [Route("GetUserRoles/{mobile}")]
        [ProducesResponseType(typeof(IEnumerable<GetUserRoleList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetUserRoleList>>> GetUserRoles(string mobile)
        {
            var query = new GetUserRoleCommand(mobile);
            var userRoles = await _mediator.Send(query);
            return Ok(userRoles);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateUser([FromBody] UserCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }
        [HttpPost]
        [Route("AddUserRefreshTokens")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddUserRefreshTokens([FromBody] CreateUserRefreshTokenCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("DeleteUserRefreshTokens")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteUserRefreshTokens([FromBody] DeleteUserRefreshTokenCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("GetSavedRefreshTokens")]
        [ProducesResponseType(typeof(GetUserRefreshTokenCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserRefreshToken>> GetSavedRefreshTokens(GetUserRefreshTokenCommand command)
        {
            var userRefreshToken = await _mediator.Send(command);
            return Ok(userRefreshToken);
        }

        [HttpPost]
        [Route("IsValidUserAsync")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> IsValidUserAsync(string mobile)
        {
            var query = new GetUserCommand(mobile);
            var user = await _mediator.Send(query);
            var isValid = (user!=null?true:false);
            return Ok(isValid);
        }

    }
}
