using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaUI.Models
{
    public class MessageModel
    {
        public string ID { get; set; }

        public string IdSender { get; set; }

        public string IdReceiver { get; set; }

        public string IdGroup { get; set; }

        public string IdReply { get; set; }

        public string Text { get; set; }

        public string Picture { get; set; }

        public DateTime SendTime { get; set; }
    }
}