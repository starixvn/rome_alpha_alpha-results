namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using Fanex.Result.Core.LinkedGames;
    using MediatR;
    using Models.Requests;

    public class LinkedGamesResultHandler :
        IRequestHandler<LinkedGamesResultQuery, LinkedGamesViewModel>
    {
        private readonly ILinkedGamesResult result;
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;

        public LinkedGamesResultHandler(ILinkedGamesResult result, BrowserHelper browserHelper, ICacheRefService cacheRefService)
        {
            this.result = result;
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
        }
        public LinkedGamesViewModel Handle(LinkedGamesResultQuery message)
        {
            var url = result.GetResult(message.CustId, message.TransId3rd, IsDesktop(), message.Language);

            return new LinkedGamesViewModel
            {
                Title = $"{cacheRefService.GetSportName(message.SportTypeId)} - {cacheRefService.GetBetTypeName(message.BetTypeId)}",
                Result = url
            };
        }

        private bool IsDesktop()
            => !browserHelper.IsMobile();
    }
}
