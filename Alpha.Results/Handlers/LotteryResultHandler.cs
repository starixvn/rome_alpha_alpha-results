namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class LotteryResultHandler :
         IRequestHandler<LotteryResultQuery, LotteryResultViewModel>
    {
        private readonly ICacheRefService cacheRefService;
        private readonly ILotteryResult lotteryResult;
        private readonly BrowserHelper browserHelper;

        public LotteryResultHandler(ICacheRefService cacheRefService,
            ILotteryResult lotteryResult,
            BrowserHelper browserHelper)
        {
            this.cacheRefService = cacheRefService;
            this.lotteryResult = lotteryResult;
            this.browserHelper = browserHelper;
        }

        public LotteryResultViewModel Handle(LotteryResultQuery message)
        {
            var result = lotteryResult.GetResult(message.CustId.ToString(), !browserHelper.IsMobile(), message.EventDate, message.RootUrl, message.LanguageKey);

            return new LotteryResultViewModel(cacheRefService)
            {
                ResultUrl = result
            };
        }
    }
}
