using BlocedCountriesApi.DTOs;
using BlocedCountriesApi.Features.IP.Queries.Models;
using BlocedCountriesApi.Models;
using BlocedCountriesApi.Services.AbstractServices;
using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;
using System.Net;

namespace BlocedCountriesApi.Features.IP.Queries.Handlers
{
    public class IpQueriyHandler: ResponseHandler,IRequestHandler<ChecklockedQueriy, Response<bool>>,
        IRequestHandler<LookupIPQueriy, Response<IpApiResponse>>
    {
        #region Fields
        private readonly IIpLookupService _ipLookupService;
        private readonly ICountryService countryService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogService logService;
        #endregion
        #region Constructor
        public IpQueriyHandler(IIpLookupService ipLookupService, ICountryService service,IHttpContextAccessor httpContextAccessor,
            ILogService logService)
        {
            _ipLookupService = ipLookupService; 
            _httpContext = httpContextAccessor;
            this.countryService= service;   
            this.logService = logService;
        }

        


        #endregion
        #region Methods
public async Task<Response<bool>> Handle(ChecklockedQueriy request, CancellationToken cancellationToken)
        {
            var ip = _httpContext.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var userAgent = _httpContext?.HttpContext?.Request.Headers["User-Agent"].ToString() ?? "Unknown";
            var result=await _ipLookupService.LookupIpAsync(ip);
            if (result == null) return null;
            var checkResult = await countryService.ExistsAsync(result.CountryCode);
            var Attempt = new BlockedAttemptLog(ip, result.CountryCode, checkResult, userAgent);
            await logService.AddAsync(Attempt);
            if (checkResult) return Success(true);
            return Success(false);  
        }

        public async Task<Response<IpApiResponse>> Handle(LookupIPQueriy request, CancellationToken cancellationToken)
        {
            var ip = request.ipAddress;

            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = _httpContext.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            }

            if (string.IsNullOrWhiteSpace(ip) || !IsValidIp(ip))
            {
                return BadRequest<IpApiResponse>("Invalid IP Address");
            }
            if (request.ipAddress==null) ip = _httpContext.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var result = await _ipLookupService.LookupIpAsync(ip);
            if (result == null) return NotFound<IpApiResponse>("IP info not found"); ;
            var ipApiResponse = new IpApiResponse
            {
                ip = result.Ip,
                country_code = result.CountryCode,
                country_name = result.CountryName,
                org = result.Org,
            };
            return Success(ipApiResponse);
        }


        private  bool IsValidIp(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return false;
            return IPAddress.TryParse(ipAddress, out _);
        }
        #endregion
    }
}
