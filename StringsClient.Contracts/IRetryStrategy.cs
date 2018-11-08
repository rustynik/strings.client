using StringsClient.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StringsClient.Contracts
{
    /// <summary>
    /// Повтор выполнения операции до успеха или выполнения иного условия
    /// </summary>
    public interface IRetryStrategy
    {
        Task<TResult> ScheduleRetry<TResult>(Func<Task<TResult>> attempt)
            where TResult : IResult;
    }
}
