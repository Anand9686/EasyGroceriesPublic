using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Domain.Common;

namespace Utils.Domain.Entities
{
    public class UnitDetail:EntityBase
    {
        public int UnitId { get; set; }
        public string UnitDescription { get; set; }
        public int UnitValue { get; set; }
    }
}
