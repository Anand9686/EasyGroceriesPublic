using Categories.Domain.Common;
using System;

namespace Categories.Domain.Entites
{
    public class Category :EntityBase 
    {
        public string CategoryName { get; set; }
        public string CategoryDescr { get; set; }
        public int CategoryParent { get; set; }
       public bool Flag { get; set; }
   
    }
}
