namespace Alpha.Results.Site.Handlers
{
    using System;
    using Fanex.Common.Helper;
    using Fanex.Logging.Extensions.Web;
    using Fanex.Result.Core.PokerGames;
    using Fanex.Result.Core.PokerGames.Models;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Services;

    public class PokerGamesHandler : IRequestHandler<PokerGamesResultQuery, PokerGamesViewModel>
    {
        private readonly ICacheRefService cacheRefService;

        public PokerGamesHandler(ICacheRefService cacheRefService)
        {
            this.cacheRefService = cacheRefService;
        }

        public PokerGamesViewModel Handle(PokerGamesResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");
            string result;
            bool isSuccess;

            try
            {
                var service = new PokerGamesResult();
                result = service.GetResult(message.CustId, message.GameTypeId, message.TransId3rd, (ViewerLevel)message.RoleId, message.Language);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                result = ex.Message;
                isSuccess = false;
            }

            var viewModel = new PokerGamesViewModel
            {
                Title = $"{cacheRefService.GetSportName(message.SportTypeId)} - {cacheRefService.GetBetTypeName(Convert.ToInt32(message.GameTypeId))}",
                Result = result,
                IsSuccess = isSuccess
            };

            return viewModel;
        }
    }
}