using BlocedCountriesApi.Models;
using BlockedCountriesApi.Bases.ResponseBases;
using BlockedCountriesApi.Wrappers;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Queries.Models
{
    public class GetBlockedCountriesQuery(int pageNumber,int pageSize,string search) :  IRequest<Response<PaginatedResult<BlockedCountry>>>
    {
        public int PageNumber = pageNumber;
        public int PageSize = pageSize;
        public string? Search = search;
    }
}
