namespace Alpha.Results.Site.Handlers
{
    using System;
    using Constants;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class TableGamesResultHandler :
         IRequestHandler<TableGamesResultQuery, TableGamesResultViewModel>
    {
        public TableGamesResultViewModel Handle(TableGamesResultQuery message)
        {
            var resultPath = string.Format(
                "{0}game/keno/kenoresult/resultdetail?date={1}&language={2}&productId={4}&customerid={3}",
                message.RootUrl,
                DateTime.Today.ToString("yyyyMMdd"),
                message.LanguageKey,
                message.CustId,
                ProductIdConstants.TableGames);

            var extendTokenPath = $"{message.RootUrl}game/keno/kenoresult/extendtoken?productId={ProductIdConstants.TableGames}&userid={message.CustId}";

            return new TableGamesResultViewModel
            {
                ResultPath = resultPath,
                ExtendTokenPath = extendTokenPath
            };
        }
    }
}
