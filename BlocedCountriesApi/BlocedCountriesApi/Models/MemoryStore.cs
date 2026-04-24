using System.Collections.Concurrent;

namespace BlocedCountriesApi.Models
{
    public  class MemoryStore
    {
        #region Fields 
        public ConcurrentDictionary<string, BlockedCountry> BlockedCountries = new();
        public   ConcurrentDictionary<string, TemporaryBlock> TempBlockedCountries = new();
        public   List<BlockedAttemptLog> Logs = new();
        #endregion

      
       
    }
}
