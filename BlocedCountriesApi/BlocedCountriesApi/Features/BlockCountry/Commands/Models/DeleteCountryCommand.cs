using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Commands.Models
{
    public class DeleteCountryCommand(string countryCode) :IRequest<Response<string>>
    {
        public string CountryCode { get; set; } = countryCode;

    }
}
