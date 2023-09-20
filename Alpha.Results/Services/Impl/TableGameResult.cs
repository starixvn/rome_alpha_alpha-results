namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ConfigurationHelper;
    using Fanex.Result.Core.KenoLotteryTG;

    public class TableGameResult : KenoLotteryTGResult, ITableGameResult
    {
        public TableGameResult(string sectionName, IConfigurationHelper configurationHelper) : base(sectionName, configurationHelper) { }
    }
}