using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryWebApp.Pages.Login.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryWebApp.Pages.Login.UI
{
    public class LoginModel : PageModel
    {
        public User LoginUser { get; set; } = new User();
    }
}
