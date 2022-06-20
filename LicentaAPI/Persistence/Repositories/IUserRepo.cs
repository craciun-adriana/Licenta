using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    public interface IUserRepo
    {
        public IEnumerable<AppUser> GetUsersByIds(IEnumerable<string> ids);

        public AppUser GetUserById(string idUser);

        public void Update(AppUser entity);

        public void Delete(AppUser entity);

        public IEnumerable<AppUser> FindUsersByUsername(string username);

        public IEnumerable<AppUser> FindFriendsByUsername(string username, IEnumerable<string> listfiendsId);
    }
}