namespace BlocedCountriesApi.Services.AbstractServices
{
    public interface ITemporaryBlockService
    {
        public bool IsTemporarilyBlocked(string countryCode);
        public void AddTemporaryBlock(string countryCode, int durationMinutes);
    }
}
