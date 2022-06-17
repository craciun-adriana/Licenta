using LicentaAPI.AppServices.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IFriendshipRepo _friendshipRepo;
        private readonly IMappingCoordinator _mapper;

        public UserService(IUserRepo userRepo, IFriendshipRepo friendshipRepo, IMappingCoordinator mapper)
        {
            _userRepo = userRepo;
            _friendshipRepo = friendshipRepo;
            _mapper = mapper;
        }

        public IEnumerable<PublicUserDetails> FindFriendsByUsername(string username, string loggedInUserId)
        {
            var listFriendsId = _friendshipRepo.GetFriendsIdForUser(loggedInUserId);
            var friends = _userRepo.FindFriendsByUsername(username, listFriendsId);
            return _mapper.Map<AppUser, PublicUserDetails>(friends);
        }

        public IEnumerable<PublicUserDetails> FindUsersByUsername(string username, string loggedInUserId)
        {
            var users = _userRepo.FindUsersByUsername(username)
                .Where(u => u.Id != loggedInUserId);
            return _mapper.Map<AppUser, PublicUserDetails>(users);
        }

        public PublicUserDetails GetUserById(string userId)
        {
            var user = _userRepo.GetUserById(userId);
            return _mapper.Map<AppUser, PublicUserDetails>(user);
        }

        public void Update(AppUser user)
        {
            _userRepo.Update(user);
        }
    }
}