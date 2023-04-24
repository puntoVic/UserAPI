using Common;
using Common.Helpers;
using Data.Contracts;
using Entities.Definitions;
using Entities.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IDataContext dataContext;

        public UserDataAccess(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IUser> CreateUser(IUser user)
        {
            var result = await dataContext.CreateUser(user);
            if (!result)
            {
                return null;
            }
            return user;
        }

        public bool IsDuplicated(IUser user)
        {
            var result = dataContext.Users.Where(x => x.Email == user.Email || x.Phone == user.Phone);
            return result.Count() > 0;
        }
    }
}
