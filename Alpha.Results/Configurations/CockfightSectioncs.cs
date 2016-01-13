namespace Alpha.Results.Site.Configurations
{
    using System.Configuration;

    public class CockfightSectioncs : ConfigurationSection
    {
        private static CockfightSectioncs instance
            = ConfigurationManager.GetSection("CockfightSectioncs") as CockfightSectioncs;

        public static CockfightSectioncs Instance
        {
            get
            {
                return instance;
            }
        }

        [ConfigurationProperty("AuthenticationUrl", IsRequired = false)]
        public string AuthenticationUrl
        {
            get
            {
                return (string)this["AuthenticationUrl"];
            }
        }

        [ConfigurationProperty("ResultUrl", IsRequired = true)]
        public string ResultUrl
        {
            get
            {
                return (string)this["ResultUrl"];
            }
        }

        [ConfigurationProperty("SiteId", IsRequired = true)]
        public string SiteId
        {
            get
            {
                return (string)this["SiteId"];
            }
        }

        [ConfigurationProperty("VendorName", IsRequired = true)]
        public string VendorName
        {
            get
            {
                return (string)this["VendorName"];
            }
        }

        [ConfigurationProperty("VendorKey", IsRequired = true)]
        public string VendorKey
        {
            get
            {
                return (string)this["VendorKey"];
            }
        }
    }
}