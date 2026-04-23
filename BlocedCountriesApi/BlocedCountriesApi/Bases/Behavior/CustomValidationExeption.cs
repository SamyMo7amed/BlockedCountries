namespace BlockedCountriesApi.Bases.Behavior
{
    public class CustomValidationExeption : Exception
    {
        public List<string> Errors { get; set; }
        public CustomValidationExeption(List<string> errors) : base("Validation Failed")
        {
            Errors = errors;
        }

    }
}
