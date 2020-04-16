namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Constants;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class TableGamesResultHandler :
         IRequestHandler<TableGamesResultQuery, TableGamesResultViewModel>
    {
        private readonly BrowserHelper browserHelper;

        public TableGamesResultHandler(BrowserHelper browserHelper)
        {
            this.browserHelper = browserHelper;
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

            return new TableGamesResultViewModel
            {
                ResultPath = resultPath,
                ExtendTokenPath = extendTokenPath
            };
        }
        private string GetPlatform()
            => browserHelper.IsMobile() || browserHelper.IsTablet() ? "S" : "W";
    }
}
