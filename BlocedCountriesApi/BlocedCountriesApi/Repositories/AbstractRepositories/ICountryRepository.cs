using BlocedCountriesApi.Models;

namespace BlocedCountriesApi.Repositories.AbstractRepositories
{
    public interface ICountryRepository
    {
        Task AddAsync(BlockedCountry country);
        Task RemoveAsync(string countryCode);
        Task<BlockedCountry?> GetAsync(string countryCode);
        Task<IEnumerable<BlockedCountry>> GetAllAsync();

        Task<bool> ExistsAsync(string countryCode);
    }
}
