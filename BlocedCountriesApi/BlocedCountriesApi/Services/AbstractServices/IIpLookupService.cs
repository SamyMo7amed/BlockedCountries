namespace BlocedCountriesApi.Services.AbstractServices
{
    public interface IIpLookupService
    {
        Task<IpLookupResult?> LookupIpAsync(string ip);
    }
}
