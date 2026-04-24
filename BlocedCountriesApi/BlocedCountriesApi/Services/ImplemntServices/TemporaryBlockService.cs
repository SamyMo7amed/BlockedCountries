using BlocedCountriesApi.Services.AbstractServices;

namespace BlocedCountriesApi.Services.ImplemntServices
{
    public class TemporaryBlockService : ITemporaryBlockService
    {
        #region Fields 

        #endregion

        #region Constructor 


        #endregion

        #region Methods 
 public void AddTemporaryBlock(string countryCode, int durationMinutes)
        {
            throw new NotImplementedException();
        }

        public bool IsTemporarilyBlocked(string countryCode)
        {
            throw new NotImplementedException();
        }
        #endregion
       
    }
}
