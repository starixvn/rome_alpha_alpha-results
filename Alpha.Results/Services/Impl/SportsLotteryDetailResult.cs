namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISportsLotteryDetailResult : IThirdPartyResult
    {
    }

    public class SportsLotteryDetailResult : ThirdPartyResult, ISportsLotteryDetailResult
    {
        public SportsLotteryDetailResult(string sectionName) : base(sectionName) { }
    }
}