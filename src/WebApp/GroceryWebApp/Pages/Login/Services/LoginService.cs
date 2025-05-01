using GroceryWebApp.Extensions;
using GroceryWebApp.Pages.Login.Model;
using GroceryWebApp.Pages.Products.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;

        public LoginService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _client.GetAsync($"/Api/Login");
            return await response.ReadContentAs<List<User>>();
        }
        public async Task<User> GetUser(string mobile)
        {
            var response = await _client.GetAsync($"/Api/Login/GetUser/{mobile}");
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;
           
            return await response.ReadContentAs<User>(); ;
           
        }
        public async Task<IEnumerable<UserRole>> GetUserRoles(string mobile)
         {
            var response = await _client.GetAsync($"/Api/Login/GetUserRoles/{mobile}");
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;
           
            return await response.ReadContentAs<List<UserRole>>();
           
        }
        public async Task<int> CreateUser(User model)
        {
            var response = await _client.PostAsJson($"/Api/Login", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<int> AddUserRefreshTokens(UserToken refreshtoken)
        {
            var response = await _client.PostAsJson($"/Api/Login/AddUserRefreshTokens", refreshtoken);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<int> DeleteUserRefreshTokens(UserToken refreshtoken)
        {
            var response = await _client.PostAsJson($"/Api/Login/DeleteUserRefreshTokens", refreshtoken);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
        public async Task<UserToken> GetSavedRefreshTokens(UserToken refreshtoken)
        {
            var response = await _client.PostAsJson($"/Api/Login/GetSavedRefreshTokens", refreshtoken);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<UserToken>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }



    }
}
