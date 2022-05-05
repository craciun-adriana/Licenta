using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers.Models
{
    public class GroupMemberCreateRequest
    {
        [Required]
        public string IdGroup { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}