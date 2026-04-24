using BlocedCountriesApi.Features.BlockCountry.Commands.Models;
using BlocedCountriesApi.Models;
using BlocedCountriesApi.Services.AbstractServices;
using BlockedCountriesApi.Bases.ResponseBases;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Commands.Handlers
{
    public class BlockCountryHandler : ResponseHandler, IRequestHandler<AddBlockCountryCommand, Response<string>>
        ,IRequestHandler<DeleteCountryCommand, Response<string>>,
        IRequestHandler<TempBlockCountryCommand,Response<string>>
    {
        #region Fields
        private readonly ICountryService countryService;
        private readonly ITemporaryBlockService temporaryBlockService;
        #endregion

        #region Constructor
        public BlockCountryHandler(ICountryService countryService, ITemporaryBlockService temporaryBlockService)
        {
            this.countryService = countryService;
            this.temporaryBlockService = temporaryBlockService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddBlockCountryCommand request, CancellationToken cancellationToken)
        {
            var code = request.CountryCode?.Trim().ToUpper();


            if (string.IsNullOrWhiteSpace(code))
                return BadRequest<string>("Country code is required");
                

          
            if (code.Length != 2)
                return BadRequest<string>("Country code must be 2 letters");
  
          
            var exists = await countryService.ExistsAsync(code);
            if (exists) return Success<string>("Country already blocked");
                

          
            var country = new BlockedCountry(code);
            await countryService.AddAsync(country);

            return Success<string>("Success");
        }

        public async Task<Response<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var code = request.CountryCode?.Trim().ToUpper();


            if (string.IsNullOrWhiteSpace(code))
                return BadRequest<string>("Country code is required");

            if (code.Length != 2)
                return BadRequest<string>("Country code must be 2 letters");

            var exists = await countryService.ExistsAsync(code);
            if (!exists) return Success<string>("Country already not blocked");
            await countryService.RemoveAsync(code);

            return Success<string>("Success");
        }

        public async Task<Response<string>> Handle(TempBlockCountryCommand request, CancellationToken cancellationToken)
        {
            var code = request.CountryCode.Trim().ToUpper();


            if (request.BlockedMinutes < 1 || request.BlockedMinutes > 1440)
                return BadRequest<string>("Invalid duration");
               

            if ( temporaryBlockService.IsTemporarilyBlocked(code))
                return BadRequest<string>("Already temporarily blocked");
           

           
            countryService.AddAsync(new BlockedCountry(code));
           temporaryBlockService.AddTemporaryBlock(code,request.BlockedMinutes);
           

            return Success<string>("Success");
        }
        #endregion

    }
}
