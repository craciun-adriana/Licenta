using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class MessageCreateRequest
    {
        public string IdReceiver { get; set; }

        public string IdGroup { get; set; }

        [Required]
        public string Text { get; set; }
    }
}