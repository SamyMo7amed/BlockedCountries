using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;
using BlocedCountriesApi.Repositories.ImplementRepositories;
using BlocedCountriesApi.Services.AbstractServices;

namespace BlocedCountriesApi.Services.ImplemntServices
{
    public class LogService : ILogService
    {
        #region Fields 
        private readonly ILogger<ILogService> logger;
        private readonly ILogRepository logRepository;
        #endregion

        #region Constructor 
        public LogService(ILogRepository logRepository, ILogger<ILogService> logger)
        {
            this.logRepository = logRepository;
            this.logger = logger;
        }

        #endregion

        #region Methods 

        #endregion
        public async Task AddAsync(BlockedAttemptLog log)
        {
            try
            {
                if (log == null)
                    throw new ArgumentNullException(nameof(log));

                await logRepository.AddAsync(log);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding log for IP {IpAddress}", log?.IpAddress);
                throw;
            }

        }

        public async Task<IEnumerable<BlockedAttemptLog>> GetAllAsync()
        {
            try
            {
                return await logRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving logs");
                throw;
            }
        }
    }
}
