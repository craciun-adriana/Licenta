using LicentaAPI.AppServices.Models;
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Users
{
    public interface IUserService
    {
        public IEnumerable<PublicUserDetails> FindUsersByUsername(string username);
    }
}