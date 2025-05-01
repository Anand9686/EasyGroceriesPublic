using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Features.Login.Query.GetUserRole
{
    public class GetUserRoleCommand : IRequest<IEnumerable<GetUserRoleList>>
    {
        public string Mobile { get; set; }
        public GetUserRoleCommand(string mobile)
        {
            Mobile = mobile;
        }
        public GetUserRoleCommand()
        {
        }
    }
}
