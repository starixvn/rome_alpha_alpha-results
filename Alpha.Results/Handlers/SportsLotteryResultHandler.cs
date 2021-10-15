namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using Fanex.Result.Core.SportsLottery;
    using MediatR;
    using Models.Requests;

    public class SportsLotteryResultHandler :
         IRequestHandler<SportsLotteryResultQuery, SportsLotteryResultViewModel>
    {
        private readonly ISportsLotteryResult result;
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;

        public SportsLotteryResultHandler(ISportsLotteryResult result, BrowserHelper browserHelper, ICacheRefService cacheRefService)
        {
            this.result = result;
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
        }

        public SportsLotteryResultViewModel Handle(SportsLotteryResultQuery message)
        {
            var url = result.GetResultPage(!browserHelper.IsMobile(), message.Language, message.IsDarkMode);

            return new SportsLotteryResultViewModel(cacheRefService, url);
        }
    }
}
