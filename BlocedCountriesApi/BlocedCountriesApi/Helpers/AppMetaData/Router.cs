namespace BlockedCountriesApi.Helpers.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public const string SignleRoute = "/{CountryCode}";

        public static class Country {
            public const string prefix = Rule + "countries";
            public const string block = prefix + "/block";
            public const string delete = block + SignleRoute;
            public const string GetAll = prefix + "/blocked";
            public const string temporal_block = prefix + "/temporal-block";




        }
        public static class Ip
        {
            public const string prefix = Rule + "ip";
            public const string Lookup = prefix + "/Lookup";
            public const string check_block = prefix + "/check-block";
        }
        public static class Logs {
            public const string prefix = Rule + "logs";
            public const string blocked_attempts = prefix + "/blocked-attempts";
            
        }
    }
}
