using LicentaAPI.Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class UpdateUserRequest
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
        public Sex Sex { get; set; }
    }
}