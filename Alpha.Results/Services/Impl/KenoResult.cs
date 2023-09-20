namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ConfigurationHelper;
    using Fanex.Result.Core.KenoLotteryTG;

    public class KenoResult : KenoLotteryTGResult, IKenoResult
    {
        public KenoResult(string sectionName, IConfigurationHelper configurationHelper) : base(sectionName, configurationHelper) { }
    }
}