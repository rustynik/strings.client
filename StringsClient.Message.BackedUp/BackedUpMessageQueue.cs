using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace StringsClient.Message.BackedUp
{
    /// <summary>
    /// Декоратор очереди исходящих сообщений: 
    /// перед отправкой бэкапим сообщение, после успешной отправки убираем из бэкапа
    /// TODO: а что делаем, если отправка была неуспешной? пока оставляем в бэкапе
    /// </summary>
    /// <typeparam name="T">Тип отправляемого сообщений</typeparam>
    public class BackedUpMessageQueue<T> : IMessageQueue<T>
        where T : IHasId
    {
        readonly IKeyvalueStorage<T> _backup;
        readonly IMessageQueue<T> _inner;
        public BackedUpMessageQueue(IKeyvalueStorage<T> backup, IMessageQueue<T> inner)
        {
            _backup = backup ?? throw new ArgumentNullException(nameof(backup));
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public async Task<IMessageAcknowledgement> Enqueue(T message)
        {
            await _backup.SetAsync(message);

            var result = await _inner.Enqueue(message);

            // TODO: а что делаем, если отправка была неуспешной? пока оставляем в бэкапе
            if (result.Success) await _backup.RemoveAsync(message.Id);

            return result;
        }
    }
}
