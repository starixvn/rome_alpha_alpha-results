namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ConfigurationHelper;
    using Fanex.Result.Core.KenoLotteryTG;

    public class VirtualGamesResult : KenoLotteryTGResult, IVirtualGamesResult
    {
        public VirtualGamesResult(string sectionName, IConfigurationHelper configurationHelper) : base(sectionName, configurationHelper) { }
    }
}