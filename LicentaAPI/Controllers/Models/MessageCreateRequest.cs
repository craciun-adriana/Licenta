using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class MessageCreateRequest
    {
        public string IdReceiver { get; set; }

        public string IdGroup { get; set; }

        public string IdReply { get; set; }

        [Required]
        public string Text { get; set; }

        public string Picture { get; set; }

        [Required]
        public DateTime SendTime { get; set; }
    }
}