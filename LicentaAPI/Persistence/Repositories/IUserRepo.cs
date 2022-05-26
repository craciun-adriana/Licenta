using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<AppUser> GetUsersByIds(IEnumerable<string> ids);

        public IEnumerable<AppUser> GetUserById(string idUser);

        public IEnumerable<AppUser> FindUsersByUsername(string username);
    }
}