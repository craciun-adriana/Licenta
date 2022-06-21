using LicentaAPI.AppServices.Models;
using LicentaAPI.AppServices.Users.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Users
{
    public interface IUserService
    {
        public IEnumerable<PublicUserDetails> FindUsersByUsername(string username, string loggedInUserId);

        public IEnumerable<PublicUserDetails> FindFriendsByUsername(string username, string loggedInUserId);

        public PublicUserDetails GetUserById(string userId);

        public UserUpdateResult Update(UserUpdate user);

        public void DeleteUser(string idUser);

        public IEnumerable<PublicUserDetails> GetAllUsers(bool isAdmin);
    }
}