using BlocedCountriesApi.DTOs;
using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.IP.Queries.Models
{
    public class LookupIPQueriy  : IRequest<Response<IpApiResponse>>
    {
        public string ipAddress { get; set; }

        public LookupIPQueriy() { }
        public LookupIPQueriy(string ipAddress) { 
        this.ipAddress = ipAddress; 
        }
    }
}
