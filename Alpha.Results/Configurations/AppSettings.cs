using AlphaPlus.Configurations;

namespace Alpha.Results.Site.Configurations
{
    public static class AppSettings
    {
        public static string StoredProcedurePath => ConfigurationManager.GetValue<string>("StoredProcedurePath");

        public static bool LocalTest => ConfigurationManager.GetValue<string>("LocalTest") == "1";

        public static bool Disable151_31 => ConfigurationManager.GetValue<string>("Disable151_31") == "1";

        public static string RemoteRefURL => ConfigurationManager.GetValue<string>("RemoteRefURL");
    }
}