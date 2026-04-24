using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlocedCountriesApi.Controllers
{
   
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator MediatorInstanse;
        protected IMediator Mediator => MediatorInstanse ??= HttpContext.RequestServices.GetService<IMediator>()!;
       
        public ObjectResult NewResult<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.Created => Created(string.Empty, response),
                HttpStatusCode.Unauthorized => Unauthorized(response),
                HttpStatusCode.BadRequest => BadRequest(response),
                HttpStatusCode.NotFound => NotFound(response),
                HttpStatusCode.Accepted => Accepted(response),
                HttpStatusCode.UnprocessableEntity => UnprocessableEntity(response),
                _ => BadRequest(response)// default case
            };
        }
    }
}
