using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;

namespace BlocedCountriesApi.Repositories.ImplementRepositories
{
    public class TemporaryBlockRepository : ITemporaryBlock
    {
        private readonly MemoryStore _store;

        public TemporaryBlockRepository(MemoryStore store) {
        this._store = store;
        }
        public bool IsTemporarilyBlocked(string countryCode)
        {

            if (_store.TempBlockedCountries.TryGetValue(countryCode, out var block))
            {
                if (DateTime.UtcNow < block.BlockedTime)
                    return true;


                _store.TempBlockedCountries.TryRemove(countryCode, out _);
            }

            return false;
        }
        public void AddTemporaryBlock(string countryCode, int BlockMinutes)
        {

            if (BlockMinutes < 1 || BlockMinutes > 1440)
                throw new ArgumentException("Invalid duration. Must be between 1 and 1440 minutes.");

          
            if (IsTemporarilyBlocked(countryCode))
                throw new InvalidOperationException("This country is already temporarily blocked.");

           
            var expiryDate = DateTime.UtcNow.AddMinutes(BlockMinutes);


            var newBlock = new TemporaryBlock(countryCode, BlockMinutes);
         

            _store.TempBlockedCountries.TryAdd(countryCode, newBlock);
        }
    }
    
}
