namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using Fanex.Result.Core.Happy5LinkedGames;
    using MediatR;
    using Models.Requests;

    public class Happy5LinkedGamesResultHandler :
        IRequestHandler<Happy5LinkedGamesResultQuery, Happy5LinkedGamesViewModel>
    {
        private readonly IHappy5LinkedGamesResult result;
        private readonly BrowserHelper browserHelper;
        private readonly ICacheRefService cacheRefService;

        public Happy5LinkedGamesResultHandler(IHappy5LinkedGamesResult result, BrowserHelper browserHelper, ICacheRefService cacheRefService)
        {
            this.result = result;
            this.browserHelper = browserHelper;
            this.cacheRefService = cacheRefService;
        }
        public Happy5LinkedGamesViewModel Handle(Happy5LinkedGamesResultQuery message)
        {
            var url = result.GetResult(message.CustId, message.TransId3rd, IsDesktop(), message.Language);

            return new Happy5LinkedGamesViewModel
            {
                Title = $"{cacheRefService.GetSportName(message.SportTypeId)} - {cacheRefService.GetBetTypeName(message.BetTypeId)}",
                Result = url
            };
        }

        private bool IsDesktop()
            => !browserHelper.IsMobile();
    }
}
