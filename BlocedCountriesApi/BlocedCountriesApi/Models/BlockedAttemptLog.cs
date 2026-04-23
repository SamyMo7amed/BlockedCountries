namespace BlocedCountriesApi.Models
{
    public class BlockedAttemptLog
    {
        public string IpAddress { get;  set; }
        public DateTime Timestamp { get;  set; }
        public string CountryCode { get;  set; }
        public bool IsBlocked { get;  set; }
        public string UserAgent { get;  set; }

        private BlockedAttemptLog() { }

        public BlockedAttemptLog(string ip, string countryCode, bool isBlocked, string userAgent)
        {
            IpAddress = ip;
            CountryCode = countryCode;
            IsBlocked = isBlocked;
            UserAgent = userAgent;
            Timestamp = DateTime.UtcNow;
        }
    }
}
