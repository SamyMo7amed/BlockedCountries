namespace BlocedCountriesApi.Models
{
    public class TemporaryBlock
    {
        public string CountryCode { get; private set; }
        public DateTime BlockedTime { get; private set; }

        private TemporaryBlock() { }

        public TemporaryBlock(string countryCode, int TimeByMinutes)
        {
            CountryCode = countryCode;
            BlockedTime = DateTime.UtcNow.AddMinutes(TimeByMinutes);
        }
        
    }
}
