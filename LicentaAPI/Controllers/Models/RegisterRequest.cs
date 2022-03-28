using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    /// <summary>
    /// All information that is needed to register a user.
    /// </summary>
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Sex { get; set; }
    }
}