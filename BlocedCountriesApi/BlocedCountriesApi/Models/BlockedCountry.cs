namespace BlocedCountriesApi.Models
{
    public class BlockedCountry
    {

        #region Fields 
  public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        #endregion

        #region Constructor 
 private BlockedCountry() { }

        public BlockedCountry(string countryCode, string countryName, DateTime createdAt)
        {
            CountryCode = countryCode;
            CountryName = countryName;
            CreatedAt = createdAt;
        }

        #endregion
      
       
        
        
    }
}
