using BlocedCountriesApi.Models;
using BlockedCountriesApi.Bases.ResponseBases;
using BlockedCountriesApi.Wrappers;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Queries.Models
{
    public class GetBlockedCountriesQuery :  IRequest<Response<PaginatedResult<BlockedCountry>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }

        public GetBlockedCountriesQuery() { }   
        public GetBlockedCountriesQuery(int pageNumber, int pageSize, string? search)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Search = search;
        }
      
    }
}
