﻿using System;

namespace LicentaAPI.AppServices.Messages.Model
{
    /// <summary>
    /// Class contains details about a <see cref="Message"/>
    /// </summary>
    public class MessageCreate
    {
        public string IdSender { get; set; }

        public string IdReceiver { get; set; }

        public string IdGroup { get; set; }

        public string IdReply { get; set; }

        public string Text { get; set; }

        public string Picture { get; set; }

        public DateTime SendTime { get; set; }
    }
}