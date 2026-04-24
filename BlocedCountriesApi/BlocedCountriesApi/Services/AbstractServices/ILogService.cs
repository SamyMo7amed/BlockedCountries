using BlocedCountriesApi.Models;

namespace BlocedCountriesApi.Services.AbstractServices
{
    public interface ILogService
    {
        Task AddAsync(BlockedAttemptLog log);
        Task<IEnumerable<BlockedAttemptLog>> GetAllAsync();
    }
}
