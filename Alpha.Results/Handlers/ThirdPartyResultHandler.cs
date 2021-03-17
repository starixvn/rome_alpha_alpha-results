namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.App_GlobalResources;
    using Alpha.Results.Site.Helpers;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.Core.SportsLottery;
    using Fanex.Result.ThirdParty.Models;
    using Fanex.Result.ThirdParty.Models.Views;
    using Fanex.Result.ThirdParty.Services;
    using MediatR;
    using Models.Requests;
    using Services;

    public class ThirdPartyResultHandler : IRequestHandler<ThirdPartyResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<ThirdPartyDetailResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<MaxGameResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<SportsLotteryDetailResultQuery, ThirdPartyResultViewModel>
    {
        private readonly ProductResultServiceFactory serviceFactory;
        private readonly ICacheRefService cacheRefService;
        private readonly IMaxGameResult maxGameService;
        private readonly ISportsLotteryResult sportsLotteryResult;
        private readonly BrowserHelper browserHelper;

        public ThirdPartyResultHandler(
            ProductResultServiceFactory serviceFactory,
            ICacheRefService cacheRefService,
            IMaxGameResult maxGameService,
            ISportsLotteryResult sportsLotteryResult,
            BrowserHelper browserHelper)
        {
            this.serviceFactory = serviceFactory;
            this.cacheRefService = cacheRefService;
            this.maxGameService = maxGameService;
            this.sportsLotteryResult = sportsLotteryResult;
            this.browserHelper = browserHelper;
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetResultLink(message);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyDetailResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetDetailLink(message);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }

        public ThirdPartyResultViewModel Handle(MaxGameResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = maxGameService.GetResult(message.CustId, message.TransId3rd, message.BetType, message.EndTime, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }

        public ThirdPartyResultViewModel Handle(SportsLotteryDetailResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = sportsLotteryResult.GetResultDetail(message.CustId, message.TransId3rd, !browserHelper.IsMobile(), message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }
    }
}
