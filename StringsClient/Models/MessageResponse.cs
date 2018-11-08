using StringsClient.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringsClient.Models
{
    public class MessageResponse
    {
        private MessageResponse(bool success, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        public bool Success { get; }
        public string ErrorMessage { get; }

        internal static MessageResponse Error(string validationError)
            => new MessageResponse(false, validationError);

        internal static MessageResponse Ok()
            => new MessageResponse(true);

        internal static MessageResponse From(IMessageAcknowledgement result)
            => new MessageResponse(result.Success, result.Success ? null : "Произошла какая-то ошибка");
    }
}
