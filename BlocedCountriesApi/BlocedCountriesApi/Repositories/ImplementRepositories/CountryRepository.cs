using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;
using System.Collections.Concurrent;

namespace BlocedCountriesApi.Repositories.ImplementRepositories
{
    public class CountryRepository : ICountryRepository
    {

        #region Fields 
         private readonly MemoryStore _store;
        #endregion

        #region Constructor 

        public CountryRepository(MemoryStore store)
        {
            _store = store;
        }
        #endregion

        #region Methods 
        public Task AddAsync(BlockedCountry country)
        {
            _store.BlockedCountries.TryAdd(country.CountryCode, country);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string countryCode)
        {
            _store.BlockedCountries.TryRemove(countryCode.ToUpper(), out _);
            return Task.CompletedTask;
        }

        public Task<BlockedCountry?> GetAsync(string countryCode)
        {
            _store.BlockedCountries.TryGetValue(countryCode.ToUpper(), out var country);
            return Task.FromResult(country);
        }

        public Task<IEnumerable<BlockedCountry>> GetAllAsync()
        {
            return Task.FromResult(_store.BlockedCountries.Values.AsEnumerable());
        }

        public Task<bool> ExistsAsync(string countryCode)
        {
            return Task.FromResult(_store.BlockedCountries.ContainsKey(countryCode.ToUpper()));
        }
        #endregion
       

        

        
    }
}
