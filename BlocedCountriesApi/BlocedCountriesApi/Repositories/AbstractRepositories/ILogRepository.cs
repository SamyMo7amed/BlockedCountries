using BlocedCountriesApi.Models;

namespace BlocedCountriesApi.Repositories.AbstractRepositories
{
    public interface ILogRepository
    {
        Task AddAsync(BlockedAttemptLog log);
        Task<IEnumerable<BlockedAttemptLog>> GetAllAsync();
    }
}
