using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GroceryWebApp.Pages.Categories.Model
{
    public class CategoryResponseModel
    {
        public Int64 Id { get; set; }
        [StringLength(45)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(250)]
        [Required]
        public string CategoryDescr { get; set; }
        public int CategoryParent { get; set; }
        public bool Flag { get; set; }

    }
}
