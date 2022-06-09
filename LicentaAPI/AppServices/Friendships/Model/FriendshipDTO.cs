using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Friendships.Model
{
    public class FriendshipDTO
    {
        public string ID { get; set; }

        public string IdSender { get; set; }

        public string NameSender { get; set; }

        public string PictureSender { get; set; }

        public string IdReceiver { get; set; }

        public string NameReceiver { get; set; }

        public FriendshipStatus Status { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}