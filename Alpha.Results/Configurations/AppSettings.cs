namespace Alpha.Results.Site.Configurations
{
    using System.Configuration;

    public static class AppSettings
    {
        public static string NG2SiteAppPath
        {
            get
            {
                return GetConfigValue("NG2SiteVirtualPath");
            }
        }

        public static string GetConfigValue(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }
    }
}