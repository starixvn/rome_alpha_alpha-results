namespace Alpha.Results.Site.Handlers
{
    using System;
    using Alpha.Results.Site.Models.Requests;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services;
    using Fanex.Common.Helper;
    using Fanex.Logging.Extensions.Web;
    using Fanex.Result.Core.SabaClub;
    using MediatR;

    public class SabaClubHandler : IRequestHandler<SabaClubResultQuery, SabaClubViewModel>
    {
        private readonly ICacheRefService cacheRefService;

        public SabaClubHandler(ICacheRefService cacheRefService)
        {
            this.cacheRefService = cacheRefService;
        }

        public SabaClubViewModel Handle(SabaClubResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");
            string result;
            bool isSuccess;

            try
            {
                var service = new SabaClubResult();
                result = service.GetResult(message.CustId, message.GameRoundId, message.GameId, message.SiteId, message.Language);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                result = ex.Message;
                isSuccess = false;
            }

            var viewModel = new SabaClubViewModel
            {
                Title = $"{cacheRefService.GetSportName(message.SportId)} - {cacheRefService.GetBetTypeName(Convert.ToInt32(message.GameId))}",
                Result = result,
                IsSuccess = isSuccess
            };

            return viewModel;
        }
    }
}