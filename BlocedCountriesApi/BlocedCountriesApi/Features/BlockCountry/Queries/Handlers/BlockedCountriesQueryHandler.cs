using BlocedCountriesApi.Features.BlockCountry.Queries.Models;
using BlocedCountriesApi.Models;
using BlocedCountriesApi.Services.AbstractServices;
using BlockedCountriesApi.Bases.ResponseBases;
using BlockedCountriesApi.Wrappers;
using MediatR;

namespace BlocedCountriesApi.Features.BlockCountry.Queries.Handlers
{
    public class BlockedCountriesQueryHandler : ResponseHandler, IRequestHandler<GetBlockedCountriesQuery, Response<PaginatedResult<BlockedCountry>>>
    {
        #region Fields
        private readonly ICountryService countryService;
        #endregion
        #region Constructor
        public BlockedCountriesQueryHandler(ICountryService countryService)
        {
            this.countryService = countryService;
        }

       

        #endregion

        #region Methods


        public async Task<Response<PaginatedResult<BlockedCountry>>> Handle(GetBlockedCountriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await countryService.GetAllAsync();


                if (!string.IsNullOrWhiteSpace(request.Search))
                {
                    var search = request.Search.Trim();

                    data = data.Where(x =>
                        x.CountryCode.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        x.CountryName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    );
                }


                return Success<PaginatedResult<BlockedCountry>>(await data.ToPaginationlist(request.PageNumber, request.PageSize));
            }
            catch (Exception ex) {

                throw;
            }
            
        }
        #endregion

    }
}
