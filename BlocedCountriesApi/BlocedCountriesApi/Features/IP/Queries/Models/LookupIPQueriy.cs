using BlocedCountriesApi.DTOs;
using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.IP.Queries.Models
{
    public class LookupIPQueriy(string _ipAddress)  : IRequest<Response<IpApiResponse>>
    {
        public string ipAddress { get; set; } = _ipAddress;
    }
}
