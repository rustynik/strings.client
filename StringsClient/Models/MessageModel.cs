using StringsClient.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsClient.Models
{
    public class MessageModel
    {
        public string Message { get; set; }
        public string IP { get; set; }

        internal static MessageModel From(MessageRequest request, string ip)
        => new MessageModel
        {
            Message = request.Message,
            IP = ip
        };
    }
}
