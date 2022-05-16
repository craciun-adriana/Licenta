using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFUserRepository : IUserRepo
    {
        private AppDbContext _dbContext;

        public EFUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AppUser> GetUsersByIds(IEnumerable<string> ids)
        {
            return _dbContext.Users.Where(user => ids.Contains(user.Id));
        }
    }
}