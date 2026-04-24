using BlocedCountriesApi.DTOs;
using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.IP.Queries.Models
{
    public class ChecklockedQueriy : IRequest<Response<bool>>
    {
        public ChecklockedQueriy() { }
    }
}
