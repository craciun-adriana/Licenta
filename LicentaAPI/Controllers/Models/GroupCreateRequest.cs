using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class GroupCreateRequest
    {
        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}