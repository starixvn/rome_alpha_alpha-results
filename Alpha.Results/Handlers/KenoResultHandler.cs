namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class KenoResultHandler :
         IRequestHandler<KenoResultQuery, KenoResultViewModel>
    {
        private readonly ICacheRefService cacheRefService;
        private readonly IKenoResult kenoResult;
        private readonly BrowserHelper browserHelper;

        public KenoResultHandler(ICacheRefService cacheRefService,
            IKenoResult kenoResult,
            BrowserHelper browserHelper)
        {
            this.cacheRefService = cacheRefService;
            this.kenoResult = kenoResult;
            this.browserHelper = browserHelper;
        }

        public KenoResultViewModel Handle(KenoResultQuery message)
        {
            var result = kenoResult.GetResult(message.CustId.ToString(), !browserHelper.IsMobile(), message.EventDate, message.RootUrl, message.LanguageKey);

            return new KenoResultViewModel
            {
                ResultUrl = result
            };
        }
    }
}
