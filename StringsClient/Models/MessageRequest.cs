using StringsClient.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsClient.Models
{
    public class MessageRequest
    {
        public string Message { get; set; }

        public bool Validate(out string error)
        {
            error = string.IsNullOrWhiteSpace(Message) ? "Пустое сообщение" : null;
            return error == null;
        }

        public static StringMessage ToStringMessage(MessageRequest request, string ip)
        => new StringMessage
        {
            Message = request.Message,
            IP = ip,
            Id = Guid.NewGuid()
        };
    }
}