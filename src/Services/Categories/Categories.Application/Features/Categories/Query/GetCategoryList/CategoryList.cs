using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Features.Categories.Query.GetCategoryList
{
   public class CategoryList
    {
        public Int64 Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescr { get; set; }
        public int CategoryParent { get; set; }
        public bool Flag { get; set; }


    }
}
