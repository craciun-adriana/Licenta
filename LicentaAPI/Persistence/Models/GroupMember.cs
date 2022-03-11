using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds information about which users are in a group and if they are admins.
    /// </summary>
    public class GroupMember
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public string IdGroup { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string IdUser { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}