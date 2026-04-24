using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Commands.Models
{
    public class TempBlockCountryCommand(string countryCode, int blockedMinutes) : IRequest<Response<string>>
    {
        public string CountryCode = countryCode;
        public int BlockedMinutes=blockedMinutes;

    }
}
