using StringsClient.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace StringsClient.Contracts
{
    public interface IMessageQueue<T>
    {
        Task<IMessageAcknowledgement> Enqueue(T message);
    }
}
