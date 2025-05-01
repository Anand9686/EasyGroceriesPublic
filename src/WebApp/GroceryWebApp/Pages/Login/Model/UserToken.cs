using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Login.Model
{
   public  class UserToken
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
    }
}
