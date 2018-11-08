using StringsClient.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace StringsClient.Contracts
{
    /// <summary>
    /// (Персистетное) хранилище пар "ключ-знамение" 
    /// </summary>
    /// <typeparam name="TValue">Тип хранимого объекта</typeparam>
    public interface IKeyvalueStorage<TValue>
        where TValue : IHasId
    {
        Task<TValue> GetAsync(Guid id);
        Task SetAsync(TValue value);

        Task<TValue> RemoveAsync(Guid id);
    }
}
