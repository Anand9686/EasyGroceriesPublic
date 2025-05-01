using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Features.Tokens.Delete
{
    public class DeleteUserRefreshTokenCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }

        public DeleteUserRefreshTokenCommand(string userName, string refreshToken)
        {
            UserName = userName;
            RefreshToken = refreshToken;
        }

        public DeleteUserRefreshTokenCommand()
        {
        }
    }
}
