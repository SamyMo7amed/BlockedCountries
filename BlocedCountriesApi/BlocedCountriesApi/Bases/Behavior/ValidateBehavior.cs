using FluentValidation;
using MediatR;

namespace BlockedCountriesApi.Bases.Behavior
{
    public class ValidateBehavior<TRequest, TResopnse> : IPipelineBehavior<TRequest, TResopnse> where TRequest : IRequest<TResopnse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        

        public ValidateBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
          
        }

        public async Task<TResopnse> Handle(TRequest request, RequestHandlerDelegate<TResopnse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(x => x.Errors).Where(x => x != null).ToList();

                if (failures.Count != 0)
                {
                    var errorsmessages = failures
                                                .Select(x => x.ErrorMessage)
                                                        .ToList();

                    throw new CustomValidationExeption(errorsmessages);
                }


            }
            return await next();

        }
    }
}

    

    

