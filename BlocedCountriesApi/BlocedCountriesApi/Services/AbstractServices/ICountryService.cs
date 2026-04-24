using BlocedCountriesApi.Models;

namespace BlocedCountriesApi.Services.AbstractServices
{
    public interface ICountryService
    {
        Task AddAsync(BlockedCountry country);
        Task RemoveAsync(string countryCode);
        Task<BlockedCountry?> GetAsync(string countryCode);
        Task<IEnumerable<BlockedCountry>> GetAllAsync();

        Task<bool> ExistsAsync(string countryCode);
    }
}
