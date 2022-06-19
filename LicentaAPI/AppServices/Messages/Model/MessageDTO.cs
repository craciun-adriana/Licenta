using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Messages.Model
{
    public class MessageDTO
    {
        public string ID { get; set; }

        public string IdSender { get; set; }

        public string NameSender { get; set; }

        public string IdReceiver { get; set; }

        public string NameReceiver { get; set; }

        public string IdGroup { get; set; }

        public string Text { get; set; }

        public DateTime SendTime { get; set; }
    }
}