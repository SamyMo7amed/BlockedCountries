using BlocedCountriesApi.DTOs;
using BlocedCountriesApi.Helpers.Results;
using BlocedCountriesApi.Models;
using BlocedCountriesApi.Services.AbstractServices;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace BlocedCountriesApi.Services.ImplemntServices
{
    public class IpLookupService : IIpLookupService
    {

        #region Fields 
        private readonly HttpClient _httpClient;
        private readonly MemoryStore _store;
        private readonly ILogger<IpLookupService> _logger;
        #endregion

        #region Constructor 

        public IpLookupService(
        HttpClient httpClient,
        MemoryStore store,
        ILogger<IpLookupService> logger)
        {
            _httpClient = httpClient;
            _store = store;
            _logger = logger;
        }
        #endregion

        #region Methods 
        public async Task<IpLookupResult?> LookupIpAsync(string ip)
        {
            try
            {
                if (ip=="::1"||ip=="127.0.0.1") ip = "8.8.8.8";

                var url = $"https://ipapi.co/{ip}/json/";

               
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharp-App");
                

                var response = await _httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {

                    _logger.LogWarning("IP API Make To Many Requestes  for {ip}", ip);
                    return null;
                }
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("IP API failed for {ip}", ip);
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<IpApiResponse>(json);

                if (data == null)
                    return null;

                var result = new IpLookupResult
                {
                    Ip = ip,
                    CountryCode = data.country_code,
                    CountryName = data.country_name,
                    Org = data.org
                };

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calling IP API for {ip}", ip);
                return null;
            }

        #endregion

        }


        

    }
    }
