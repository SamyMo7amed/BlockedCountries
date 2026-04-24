using BlocedCountriesApi.Features.IP.Queries.Models;
using BlockedCountriesApi.Helpers.AppMetaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BlocedCountriesApi.Controllers
{

   
    public class IpController : AppControllerBase
    {
        [HttpGet(Router.Ip.Lookup)]
        
        public async Task<IActionResult> Lookup([FromQuery] string? ipAddress)
        {

            var result= await Mediator.Send(new LookupIPQueriy(ipAddress));
            return NewResult(result);
        }
        [HttpGet(Router.Ip.check_block)]
        public async Task<IActionResult> Lookup()
        {

            var result = await Mediator.Send(new ChecklockedQueriy());
            return NewResult(result);
        }

    }
}
