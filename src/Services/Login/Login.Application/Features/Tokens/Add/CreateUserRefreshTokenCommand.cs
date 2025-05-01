using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Features.Tokens.Add
{
    public class CreateUserRefreshTokenCommand:IRequest<int>
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }

        public CreateUserRefreshTokenCommand(string userName, string refreshToken)
        {
            UserName = userName;
            RefreshToken = refreshToken;
        }

        public CreateUserRefreshTokenCommand()
        {
        }

    }
}
