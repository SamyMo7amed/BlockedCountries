using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;
using BlocedCountriesApi.Services.AbstractServices;

namespace BlocedCountriesApi.Services.ImplemntServices
{
    public class CountryService : ICountryService
    {
        #region Fields 
           private readonly ILogger<ICountryService> logger;
        private readonly ICountryRepository countryRepository;
        #endregion

        #region Constructor 
        public CountryService(ILogger<ICountryService> logger,ICountryRepository countryRepository)
        {
            this.logger = logger;
            this.countryRepository = countryRepository;
        }

        #endregion
      

        #region Methods 
  public  async Task? AddAsync(BlockedCountry country)
        {
            try
            {
                if (country == null)
                    throw new ArgumentNullException(nameof(country));

                await countryRepository.AddAsync(country);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding country {CountryCode}", country?.CountryCode);
                throw;
            }
        }

        public async Task<bool> ExistsAsync(string countryCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                    return false;

                var country = await countryRepository.GetAsync(countryCode);
                return country != null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error checking existence of country {CountryCode}", countryCode);
                throw;
            }
        }

        public async Task<IEnumerable<BlockedCountry>> GetAllAsync()
        {
            try
            {
                return await countryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while getting all countries");
                throw;
            }
        }

        public async Task<BlockedCountry?> GetAsync(string countryCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                    return null;

                return await countryRepository.GetAsync(countryCode);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while getting country {CountryCode}", countryCode);
                throw;
            }
        }

        public async Task RemoveAsync(string countryCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                    return;

                await countryRepository.RemoveAsync(countryCode);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while removing country {CountryCode}", countryCode);
                throw;
            }
        }
        #endregion
      
    }
}
