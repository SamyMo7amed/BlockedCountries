namespace BlocedCountriesApi.Repositories.AbstractRepositories
{
    public interface ITemporaryBlock
    {
        public bool IsTemporarilyBlocked(string countryCode);
        public void AddTemporaryBlock(string countryCode, int durationMinutes);

    }
}
