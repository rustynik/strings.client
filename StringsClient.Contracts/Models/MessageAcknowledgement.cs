using System;
using System.Collections.Generic;
using System.Text;

namespace StringsClient.Contracts.Models
{
    public class MessageAcknowledgement : IMessageAcknowledgement
    {
        public bool Success { get; private set; }

        public static MessageAcknowledgement Ok => new MessageAcknowledgement { Success = true };

        public static MessageAcknowledgement Error => new MessageAcknowledgement { Success = false };
    }
}
