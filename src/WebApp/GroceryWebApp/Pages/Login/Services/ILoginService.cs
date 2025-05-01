using GroceryWebApp.Pages.Login.Model;
using GroceryWebApp.Pages.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Login.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string mobile);
        Task<IEnumerable<UserRole>> GetUserRoles(string mobile);
        Task<int> CreateUser(User model);

        Task<int> AddUserRefreshTokens(UserToken refreshtoken);
        Task<int> DeleteUserRefreshTokens(UserToken refreshtoken);
        Task<UserToken> GetSavedRefreshTokens(UserToken refreshtoken);
    }
}
