using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace StringsClient.RetryStrategies
{
    public class PeriodicRetryStrategy : IRetryStrategy
    {
        readonly int _delay;
        public PeriodicRetryStrategy(int delay)
        {
            _delay = delay;
        }
        public async Task<TResult> ScheduleRetry<TResult>(Func<Task<TResult>> attempt)
            where TResult : IResult
        {
            while (true) // выполняется вечно
            {
                // спим указанный интервал
                await Task.Delay(_delay);

                var result = await attempt();
                if (result.Success) return result;
            }
        }
    }
}
