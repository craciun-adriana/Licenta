using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds information about a group.
    /// </summary>
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