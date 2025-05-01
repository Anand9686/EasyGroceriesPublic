using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Login.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
    }
}
