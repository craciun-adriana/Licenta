using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.Users.Models
{
    public class UserUpdate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Description { get; set; }

        public Sex Sex { get; set; }

        public DateTime LastOnline { get; set; }

        public bool IsAdmin { get; set; } = false;

        public int Rank { get; set; } = 0;
    }
}