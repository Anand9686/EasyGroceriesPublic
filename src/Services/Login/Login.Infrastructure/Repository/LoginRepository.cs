using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Domain.Entities;
using Login.Application.Persistance;
using Login.Infrastructure.Persistance;

namespace Login.Infrastructure.Repository
{
    public class LoginRepository: RepositoryBase<User>, ILoginRepository
    {
        public LoginRepository(LoginContext dbContext) : base(dbContext)
        {
        }

    public async Task<IEnumerable<User>> GetUsers()
    {
            var userList = await _dbContext.User
                    .Where(q=>q.Flag==true)
                    .ToListAsync();
        return userList;
    }

        public async Task<IEnumerable<User>> GetUser(string mobile)
        {
            var user = await _dbContext.User
                    .Where(q => q.Flag == true && q.Mobile == mobile)
                    .ToListAsync();
            return user;
        }

        public async Task<IEnumerable<UserRoleList>> GetUserRoles(string mobile)
        {
           var userroles = await (from u in _dbContext.User
                                   join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                                   join r in _dbContext.Roles on ur.RoleId equals r.Id
                                  where u.Flag == true && u.Mobile == mobile
                                   select (new UserRoleList() { UserId = u.Id, Name = u.Name, RoleName = r.RoleName }))
                                         .ToListAsync();
            return userroles;
        }
        //public async Task<int> CreateUser(User user)
        //{
        //    await _dbContext.AddAsync(user);
        //        await _dbContext.SaveChangesAsync();

        //    return 1;
        //}

        public async Task<int> AddUserRefreshTokens(UserRefreshTokens refreshtoken)
        {
            await _dbContext.UserRefreshTokens.AddAsync(refreshtoken);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _dbContext.UserRefreshTokens.Remove(item);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        public async Task<UserRefreshTokens> GetSavedRefreshTokens(string username, string refreshToken)
        {
            return await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(x => x.UserName == username && x.RefreshToken == refreshToken && x.Flag == true);
        }
        public async Task<bool> IsValidUserAsync(User user)
        {
            var u = await _dbContext.User.FirstOrDefaultAsync(o => o.Name == user.Name && o.Flag==true);
            return (u != null? true:false) ;

        }
    }
}
