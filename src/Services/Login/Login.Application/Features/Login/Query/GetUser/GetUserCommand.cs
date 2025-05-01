using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Features.Login.Query.GetUser
{
    public class GetUserCommand : IRequest<IEnumerable<GetUserList>>
    {
        public string Mobile { get; set; }
        public GetUserCommand(string mobile)
        {
            Mobile = mobile;
        }
        public GetUserCommand()
        {
        }
    }
}
