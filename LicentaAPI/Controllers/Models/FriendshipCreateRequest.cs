using LicentaAPI.Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class FriendshipCreateRequest
    {
        [Required]
        public string IdReceiver { get; set; }

        [Required]
        public FriendshipStatus Status { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }
    }
}