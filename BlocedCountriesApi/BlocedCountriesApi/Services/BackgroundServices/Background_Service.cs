using BlocedCountriesApi.Models;

namespace BlocedCountriesApi.Services.BackgroundServices
{
    public class Background_Service : BackgroundService
    {

        #region Fields 
        private readonly MemoryStore _memoryStore;
        private readonly ILogger<Background_Service> _logger;
        #endregion

        #region Constructor 

            public Background_Service(MemoryStore memoryStore,
            ILogger<Background_Service> logger
            ) { 
         this._memoryStore = memoryStore;
            this._logger = logger;
        }
        #endregion

        #region Methods 
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {

                while (!stoppingToken.IsCancellationRequested)
                {
                    var now = DateTime.UtcNow;

                    var expired = _memoryStore.TempBlockedCountries
                        .Where(x => x.Value.BlockedTime <= now)
                        .Select(x => x.Key)
                        .ToList();

                    foreach (var key in expired)
                    {
                        _memoryStore.TempBlockedCountries.TryRemove(key, out _);
                        _memoryStore.BlockedCountries.TryRemove(key, out _);
                    }

                    await Task.Delay(TimeSpan.FromMinutes(5));
                }

            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error occurred in Background Service");
                throw ex;   
            }
           
        }
        #endregion
        
        
        
    }
}
