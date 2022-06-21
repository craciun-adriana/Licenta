using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Users.Models
{
    public class UserUpdateResult
    {
        public AppUser UserUpdate { get; set; }

        public string Error { get; set; }
    }
}