using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Utils.Model
{
    public class UnitDetailModel
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string UnitDescription { get; set; }
        public int UnitValue { get; set; }
    }
}
