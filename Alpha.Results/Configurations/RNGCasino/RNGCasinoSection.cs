namespace Alpha.Results.Site.Configurations.RNGCasino
{
    using System.Configuration;

    public class RNGCasinoSection : ConfigurationSection
    {
        public static RNGCasinoSection Instance
        {
            get
            {
                return ConfigurationManager.GetSection("RNGCasinoSection") as RNGCasinoSection;
            }
        }

        [ConfigurationProperty("Configurations", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(RNGCasinoCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public RNGCasinoCollection Configurations
        {
            get
            {
                return (RNGCasinoCollection)base["Configurations"];
            }
        }

        public string TokenAPI => Configurations["GetToken"].Value;

        public string SiteId => Configurations["SiteId"].Value;

        public string Password => Configurations["PassToGetToken"].Value;

        public string HandHistoryAPI => Configurations["HandHistoryAPI"].Value;

        public string Parameters => Configurations["ParameterList"].Value;

        public string EncryptedKey => Configurations["EncryptedKey"].Value;

        public string VendorId => Configurations["VendorId"].Value;

        public string Seq => Configurations["Seq"].Value;
    }
}
