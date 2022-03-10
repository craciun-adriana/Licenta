using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Persistence.Models
{
    public class Group
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}