using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    /// <summary>
    /// All information needed to login a user.
    /// </summary>
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}