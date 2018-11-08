using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using StringsClient.Models;

namespace StringsClient.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        readonly IMessageQueue<StringMessage> _messageQueue;

        public ApiController(IMessageQueue<StringMessage> messageQueue)
        {
            _messageQueue = messageQueue ?? throw new ArgumentNullException(nameof(messageQueue));
        }

        [HttpPost]
        public async Task<MessageResponse> PostMessage([FromBody] MessageRequest request)
        {
            if (!request.Validate(out string validationError)) return MessageResponse.Error(validationError);

            return MessageResponse.From(await _messageQueue.Enqueue(MessageRequest.ToStringMessage(request, Request.Host.Value)));
        }

    }
}
