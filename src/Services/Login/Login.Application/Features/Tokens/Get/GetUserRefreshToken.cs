using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Features.Tokens.Get
{
   public class GetUserRefreshToken 
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
    }
}
