using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds the information about the messages sent in <see cref="Group"/>s or to a certain <see cref="AppUser"/>.
    ///
    /// When sending messages to a <see cref="Group"/>, <see cref="IdReceiver"/> is null and <see cref="IdGroup"/> holds the group's Id.
    /// And when sending messages to an <see cref="AppUser"/>, <see cref="IdGroup"/> is null and <see cref="IdReceiver"/> holds the user's Id.
    /// </summary>
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