using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;
using System.Collections.Concurrent;

namespace BlocedCountriesApi.Repositories.ImplementRepositories
{
    public class LogRepository : ILogRepository
    {
       private readonly MemoryStore _store;

        public LogRepository(MemoryStore store)
        {
            _store = store;
        }
        public Task AddAsync(BlockedAttemptLog log)
        {
            _store.Logs.Add(log);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<BlockedAttemptLog>> GetAllAsync()
        {
            return Task.FromResult(_store.Logs.AsEnumerable());
        }
    }

}
