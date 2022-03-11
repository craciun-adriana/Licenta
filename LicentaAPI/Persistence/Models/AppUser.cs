using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    ///This class holds information about an user of the app.
    /// </summary>
    public class AppUser
    {
        public string ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Description { get; set; }

        [Required]
        public string Sex { get; set; }

        public DateTime LastOnline { get; set; }

        [Required]
        public string password { get; set; }
    }
}