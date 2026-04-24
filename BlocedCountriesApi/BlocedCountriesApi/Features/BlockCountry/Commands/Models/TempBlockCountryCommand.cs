using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Commands.Models
{
    public class TempBlockCountryCommand : IRequest<Response<string>>
    {
        public string CountryCode { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public TempBlockCountryCommand() { }
        public TempBlockCountryCommand(string CountryCode, int DurationMinutes) { 
        
        this.CountryCode = CountryCode;
            this.DurationMinutes = DurationMinutes;
        }

    }
}
