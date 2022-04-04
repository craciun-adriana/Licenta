using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds information about an user of the app.
    /// </summary>
    public class AppUser : IdentityUser
    {
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

        public bool IsAdmin { get; set; } = false;

        public int Rank { get; set; } = 0;
    }
}