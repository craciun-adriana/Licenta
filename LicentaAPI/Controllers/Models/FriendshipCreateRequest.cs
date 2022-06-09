using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class FriendshipCreateRequest
    {
        [Required]
        public string IdReceiver { get; set; }
    }
}