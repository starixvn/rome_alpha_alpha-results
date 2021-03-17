namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using Constants;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class TableGamesResultHandler :
         IRequestHandler<TableGamesResultQuery, TableGamesResultViewModel>
    {
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;

        public TableGamesResultHandler(BrowserHelper browserHelper, ICacheRefService cacheRefService)
        {
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
        }

        public TableGamesResultViewModel Handle(TableGamesResultQuery message)
        {
            var resultPath = string.Format(
                "{0}game/keno/kenoresult/resultdetail?date={1}&language={2}&productId={4}&customerid={3}&device={5}",
                message.RootUrl,
                DateTime.Today.ToString("yyyyMMdd"),
                message.LanguageKey,
                message.CustId,
                ProductIdConstants.TableGames,
                GetPlatform());

            var extendTokenPath = $"{message.RootUrl}game/keno/kenoresult/extendtoken?productId={ProductIdConstants.TableGames}&userid={message.CustId}";

            return new TableGamesResultViewModel(cacheRefService)
            {
                ResultPath = resultPath,
                ExtendTokenPath = extendTokenPath
            };
        }
        private string GetPlatform()
            => browserHelper.IsMobile() || browserHelper.IsTablet() ? "S" : "W";
    }
}
