using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    public class Message
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string IdSender { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string IdReceiver { get; set; }

        [ForeignKey(nameof(Group))]
        public string IdGroup { get; set; }

        [ForeignKey(nameof(Message))]
        public string IdReply { get; set; }

        [Required]
        public string Text { get; set; }

        public string Picture { get; set; }

        [Required]
        public DateTime SendTime { get; set; }
    }
}