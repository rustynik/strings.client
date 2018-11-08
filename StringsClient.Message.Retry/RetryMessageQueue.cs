using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace StringsClient.Message.Retry
{
    public class RetryMessageQueue<T> : IMessageQueue<T>
    {
        readonly IRetryStrategy _retryStrategy;
        readonly IMessageQueue<T> _inner;
        public RetryMessageQueue(IRetryStrategy retryStrategy, IMessageQueue<T> inner)
        {
            _retryStrategy = retryStrategy ?? throw new ArgumentNullException(nameof(retryStrategy));
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public async Task<IMessageAcknowledgement> Enqueue(T message)
        {
            while (true)
            {
                var result = await _inner.Enqueue(message);
                if (result.Success) return result;

                await Task.Delay(1000);
            }
        }
    }
}
