using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StringsClient.KeyValueStorage.FileSystem
{
    /// <summary>
    /// TODO: это должно быть хранилище в файловой системе, но времени нет ...
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileSystemFileStorage<T> : IKeyvalueStorage<T>
        where T : IHasId
    {
        private Dictionary<Guid, T> _dict = new Dictionary<Guid, T>();

        public Task<T> GetAsync(Guid id)
        {
            return Task.FromResult(_dict[id]);
        }

        public Task<T> RemoveAsync(Guid id)
        {
            var result = Task.FromResult(_dict[id]);
            _dict.Remove(id);
            return result;
        }

        public Task SetAsync(T value)
        {
            _dict[value.Id] = value;
            return Task.CompletedTask;
        }
    }
}
