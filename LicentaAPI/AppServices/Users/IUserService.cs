using LicentaAPI.AppServices.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Users
{
    public interface IUserService
    {
        public IEnumerable<PublicUserDetails> FindUsersByUsername(string username, string loggedInUserId);

        public IEnumerable<PublicUserDetails> FindFriendsByUsername(string username, string loggedInUserId);

        public PublicUserDetails GetUserById(string userId);
    }
}