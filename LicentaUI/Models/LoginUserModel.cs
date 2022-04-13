using System.ComponentModel.DataAnnotations;

namespace LicentaUI.Models
{
    public class LoginUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}