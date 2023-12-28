namespace Alpha.Results.Site.Services.Impl
{
    using System.Threading;
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
            => remotingRefService.GetResourceDataByRefIdAndResourceId(
                "Product",
                productId.ToString(),
                LanguageCode,
                string.Empty);

        private static string LanguageCode
            => Thread.CurrentThread.CurrentCulture.Name;
    }
}