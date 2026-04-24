using BlocedCountriesApi.Features.BlockCountry.Commands.Models;
using BlocedCountriesApi.Features.BlockCountry.Queries.Models;
using BlockedCountriesApi.Helpers.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BlocedCountriesApi.Controllers
{
    
    [EnableRateLimiting("fixed")]
    public class CountryController : AppControllerBase
    {
        [HttpPost(Router.Country.block)]
        public async Task<IActionResult> BlockCountry([FromQuery] string CountryCode)
        {
            var result = await Mediator.Send(new AddBlockCountryCommand(CountryCode) );
            return NewResult(result);
        }
        [HttpDelete(Router.Country.delete)]
        public async Task<IActionResult> DeleteCountry([FromRoute] string CountryCode)
        {
            var result = await Mediator.Send(new DeleteCountryCommand(CountryCode));
            return NewResult(result);
        }
        [HttpGet(Router.Country.GetAll)]
        public async Task<IActionResult> GetCountries([FromQuery] GetBlockedCountriesQuery request)
        {
            var result = await Mediator.Send(new GetBlockedCountriesQuery(request.PageNumber,request.PageSize,request.Search));
            return NewResult(result);
        }
        [HttpGet(Router.Country.temporal_block)]
        public async Task<IActionResult> TemporarilyBlockCountry([FromQuery] TempBlockCountryCommand request)
        {
            var result = await Mediator.Send(
                new TempBlockCountryCommand(request.CountryCode, request.DurationMinutes)
            );

            return NewResult(result);
        }
    }
}
