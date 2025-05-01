using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Domain.Entities;

namespace Login.Application.Persistance
{
    public interface ILoginRepository : IAsyncRepository<User>
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUser(string mobile);
        //Task<int> CreateUser(User user);

        Task<IEnumerable<UserRoleList>> GetUserRoles(string mobile);

        Task<int> AddUserRefreshTokens(UserRefreshTokens refreshtoken);
        Task<int> DeleteUserRefreshTokens(string username, string refreshToken);
        Task<UserRefreshTokens> GetSavedRefreshTokens(string username, string refreshToken);
        Task<bool> IsValidUserAsync(User user);
    }
}
