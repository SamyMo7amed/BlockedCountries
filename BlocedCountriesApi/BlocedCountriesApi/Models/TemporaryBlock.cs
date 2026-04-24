namespace BlocedCountriesApi.Models
{
    public class TemporaryBlock
    {
        #region Fields 
  public string CountryCode { get; private set; }
        public DateTime BlockedTime { get; private set; }

        #endregion

        #region Constructor 
 private TemporaryBlock() { }

        public TemporaryBlock(string countryCode, int TimeByMinutes)
        {
            CountryCode = countryCode;
            BlockedTime = DateTime.UtcNow.AddMinutes(TimeByMinutes);
        }

        #endregion
      
       
        
    }
}
