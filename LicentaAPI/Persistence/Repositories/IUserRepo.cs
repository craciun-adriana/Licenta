using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<AppUser> GetUsersByIds(IEnumerable<string> Ids);

        public IEnumerable<AppUser> FindUsersByUsername(string username);
    }
}