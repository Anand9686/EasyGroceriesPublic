using Login.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Domain.Entities
{
    public class Roles : EntityBase
    {
        public string RoleName { get; set; }
    }
}
