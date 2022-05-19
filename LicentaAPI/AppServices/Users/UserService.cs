using LicentaAPI.AppServices.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public UserService(IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public IEnumerable<PublicUserDetails> FindUsersByUsername(string username)
        {
            var users = _userRepo.FindUsersByUsername(username);
            return _mapper.Map<AppUser, PublicUserDetails>(users);
        }
    }
}