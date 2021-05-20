namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using MediatR;
    using Models.Requests;
    using Models.Views;

    public class TableGamesResultHandler :
         IRequestHandler<TableGamesResultQuery, TableGamesResultViewModel>
    {
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;
        private readonly ITableGameResult tableGameResult;

        public TableGamesResultHandler(
            BrowserHelper browserHelper, 
            ICacheRefService cacheRefService,
            ITableGameResult tableGameResult)
        {
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
            this.tableGameResult = tableGameResult;
        }

        public TableGamesResultViewModel Handle(TableGamesResultQuery message)
        {
            var resultPath = tableGameResult.GetResult(message.CustId.ToString(), !browserHelper.IsMobile(), message.EventDate, message.RootUrl, message.LanguageKey);

            return new TableGamesResultViewModel(cacheRefService)
            {
                ResultUrl = resultPath
            };
        }
    }
}
