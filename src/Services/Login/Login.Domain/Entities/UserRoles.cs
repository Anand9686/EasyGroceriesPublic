using Login.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Domain.Entities
{
    public class UserRoles: EntityBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
