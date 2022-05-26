using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.Models
{
    public class PublicUserDetails
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Description { get; set; }

        public Sex Sex { get; set; }

        public DateTime LastOnline { get; set; }

        public bool IsAdmin { get; set; }

        public int Rank { get; set; }
    }
}