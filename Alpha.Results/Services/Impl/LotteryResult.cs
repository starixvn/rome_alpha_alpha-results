namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.KenoLotteryTG;

    public class LotteryResult : KenoLotteryTGResult, ILotteryResult
    {
        public LotteryResult(string sectionName) : base(sectionName) { }
    }
}