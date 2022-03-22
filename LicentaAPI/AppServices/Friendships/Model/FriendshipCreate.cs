using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Friendships.Model
{
    public class FriendshipCreate
    {
        public string IdSender { get; set; }

        public string IdReceiver { get; set; }

        public FriendshipStatus Status { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}