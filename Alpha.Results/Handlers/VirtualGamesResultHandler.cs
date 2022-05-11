namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;

    public class VirtualGamesResultHandler :
         IRequestHandler<VirtualGamesResultQuery, VirtualGamesResultViewModel>
    {
        private readonly IVirtualGamesResult result;
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;

        public VirtualGamesResultHandler(
            IVirtualGamesResult result,
            ICacheRefService cacheRefService, 
            BrowserHelper browserHelper)
        {
            this.result = result;
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
        }

        public VirtualGamesResultViewModel Handle(VirtualGamesResultQuery message)
        {
            var resultPath = result.GetResult(message.CustId.ToString(), !browserHelper.IsMobile(), message.EventDate, message.RootUrl, message.LanguageKey);

            return new VirtualGamesResultViewModel(cacheRefService)
            {
                ResultUrl = resultPath
            };
        }
    }
}
