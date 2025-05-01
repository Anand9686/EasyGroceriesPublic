using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Domain.Common;

namespace Utils.Domain.Entities
{
   public class Unit : EntityBase
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
    }
}
