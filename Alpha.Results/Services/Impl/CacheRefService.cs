namespace Alpha.Results.Site.Services.Impl
{
    using System.Threading;
    using AlphaPlus.Configurations;
    using Fanex.RemotingRef;

    public class CacheRefService : ICacheRefService
    {
        private readonly IRemotingRefService remotingRefService;

        public CacheRefService(IRemotingRefService remotingRefService)
        {
            this.remotingRefService = remotingRefService;
        }

        public string GetSportName(int sportTypeId)
            => remotingRefService.GetSportName(sportTypeId.ToString(), LanguageCode);

        public string GetBetTypeName(int betTypeId)
            => remotingRefService.GetBetTypeName(betTypeId.ToString(), LanguageCode);

        public string GetLeagueName(int leagueId)
            => remotingRefService.GetLeagueName(leagueId.ToString(), LanguageCode);

        public string GetLeagueName(int leagueId, int leagueGroupId)
            => remotingRefService.GetLeagueName(leagueId.ToString(), leagueGroupId.ToString(), LanguageCode, string.Empty);

        public string GetLeague3rdName(int league3rdId)
            => remotingRefService.GetLeagueName3rd(league3rdId.ToString(), LanguageCode);

        public string GetProductName(int productId)
        {
            if (AppSettings.IsSiteLabel777)
            {
                var productNameFor777 = remotingRefService.GetResourceDataByRefIdAndResourceId("Product_Saba", productId.ToString(), LanguageCode, string.Empty);

                return string.IsNullOrEmpty(productNameFor777) ?
                    remotingRefService.GetResourceDataByRefIdAndResourceId("Product", productId.ToString(), LanguageCode, string.Empty) :
                    productNameFor777;
            }

            return remotingRefService.GetResourceDataByRefIdAndResourceId(
                "Product",
                productId.ToString(),
                LanguageCode,
                string.Empty);
        }

        private static string LanguageCode
            => Thread.CurrentThread.CurrentCulture.Name;
    }
}