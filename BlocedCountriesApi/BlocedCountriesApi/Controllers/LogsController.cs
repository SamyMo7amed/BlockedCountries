using BlocedCountriesApi.Features.Logs.Queries.Models;
using BlockedCountriesApi.Helpers.AppMetaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlocedCountriesApi.Controllers
{
   
    public class LogsController : AppControllerBase
    {
        [HttpGet(Router.Logs.blocked_attempts)]
        public async Task<IActionResult> BlockedAttempts([FromQuery] GetBlockedAttemptsQueriy request )
        {
            var result = await Mediator.Send(new GetBlockedAttemptsQueriy(request.PageNumber, request.PageSize));
            return NewResult(result);
        }
    }
}
