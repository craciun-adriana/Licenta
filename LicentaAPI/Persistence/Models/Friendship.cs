using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds information about the friendship of 2 <see cref="AppUser"/>.
    /// </summary>
    public class Friendship
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string IdSender { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string IdReceiver { get; set; }

        [Required]
        public FriendshipStatus Status { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }
    }
}