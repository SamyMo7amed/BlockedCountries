using BlocedCountriesApi.Repositories.AbstractRepositories;
using BlocedCountriesApi.Repositories.ImplementRepositories;
using BlocedCountriesApi.Services.AbstractServices;

namespace BlocedCountriesApi.Services.ImplemntServices
{
    public class TemporaryBlockService : ITemporaryBlockService
    {
       
    
     #region Fields 
      private readonly ILogger<ITemporaryBlockService> logger;
      private readonly ITemporaryBlock temporaryRepository;
        #endregion

        #region Constructor 
        public TemporaryBlockService(ILogger<ITemporaryBlockService> logger, ITemporaryBlock temporaryRepository)
        {
            this.logger = logger;
            this.temporaryRepository=temporaryRepository;
            
        }

        #endregion

        #region Methods 
        public void AddTemporaryBlock(string countryCode, int blockedMinutes)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                {
                    logger.LogWarning("Attempted to add temporary block with empty country code.");
                    return;
                }

                countryCode = countryCode.ToUpper().Trim();

               

                temporaryRepository.AddTemporaryBlock(countryCode, blockedMinutes);

               
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding temporary block for country {CountryCode}", countryCode);
                throw;
            }
        }

        public bool IsTemporarilyBlocked(string countryCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                    return false;

                countryCode = countryCode.ToUpper().Trim();

                if (!temporaryRepository.IsTemporarilyBlocked(countryCode))
                    return false;

            

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while checking temporary block for country {CountryCode}", countryCode);
                return false;
            }
        }
        #endregion
       
    }
}
