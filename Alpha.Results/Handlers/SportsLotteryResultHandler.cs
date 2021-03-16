namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.SportsLottery;
    using MediatR;
    using Models.Requests;

    public class SportsLotteryResultHandler :
         IRequestHandler<SportsLotteryResultQuery, string>
    {
        private readonly ISportsLotteryResult result;
        private readonly BrowserHelper browserHelper;

        public SportsLotteryResultHandler(ISportsLotteryResult result, BrowserHelper browserHelper)
        {
            this.result = result;
            this.browserHelper = browserHelper;
        }

        public string Handle(SportsLotteryResultQuery message)
            => result.GetResultPage(!browserHelper.IsMobile(), message.Language);
    }
}
