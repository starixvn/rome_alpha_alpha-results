namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Models.Requests;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using Fanex.Common.Helper;
    using Fanex.Logging.Extensions.Web;
    using Fanex.Result.Core.CardClub;
    using MediatR;

    public class CardClubHandler : IRequestHandler<CardClubResultQuery, CardClubViewModel>
    {
        private readonly ICacheRefService cacheRefService;

        public CardClubHandler(ICacheRefService cacheRefService)
        {
            this.cacheRefService = cacheRefService;
        }

        public CardClubViewModel Handle(CardClubResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");
            string result;
            bool isSuccess;

            try
            {
                var service = new CardClubResult();
                result = service.GetResult(message.CustId, message.GameTypeId, message.TransId3rd, message.Language);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                result = ex.Message;
                isSuccess = false;
            }

            var viewModel = new CardClubViewModel
            {
                Title = $"{cacheRefService.GetSportName(message.SportTypeId)} - {cacheRefService.GetBetTypeName(Convert.ToInt32(message.GameTypeId))}",
                Result = result,
                IsSuccess = isSuccess
            };

            return viewModel;
        }
    }
}