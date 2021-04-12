namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.App_GlobalResources;
    using Alpha.Results.Site.Helpers;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.Habanero;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.Core.PPLiveCasino;
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
        IRequestHandler<SportsLotteryDetailResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<PPLiveCasinoResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<HabaneroResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<CGResultQuery, ThirdPartyResultViewModel>
    {
        private readonly ProductResultServiceFactory serviceFactory;
        private readonly ICacheRefService cacheRefService;
        private readonly IMaxGameResult maxGameService;
        private readonly ISportsLotteryResult sportsLotteryResult;
        private readonly IPPLiveCasinoResult ppLiveCasinoResult;
        private readonly IHabaneroResult habaneroResult;
        private readonly BrowserHelper browserHelper;
        private readonly IHabaneroResult cgResult;

        public ThirdPartyResultHandler(
            ProductResultServiceFactory serviceFactory,
            ICacheRefService cacheRefService,
            IMaxGameResult maxGameService,
            ISportsLotteryResult sportsLotteryResult,
            IPPLiveCasinoResult ppLiveCasinoResult,
            BrowserHelper browserHelper)
        {
            this.serviceFactory = serviceFactory;
            this.cacheRefService = cacheRefService;
            this.maxGameService = maxGameService;
            this.sportsLotteryResult = sportsLotteryResult;
            this.ppLiveCasinoResult = ppLiveCasinoResult;
            this.habaneroResult = new HabaneroResult("HabaneroResultConfigs");
            this.cgResult = new HabaneroResult("CGResultConfigs");
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

        public ThirdPartyResultViewModel Handle(PPLiveCasinoResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = ppLiveCasinoResult.GetResult(message.CustId, message.GameId3rd, message.BetType, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }
        
        public ThirdPartyResultViewModel Handle(HabaneroResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = habaneroResult.GetResult(message.CustId.ToString(), message.GameId, message.GameCode, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }

        public ThirdPartyResultViewModel Handle(CGResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = cgResult.GetResult(message.CustId.ToString(), message.GameId, message.GameCode, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }
    }
}
