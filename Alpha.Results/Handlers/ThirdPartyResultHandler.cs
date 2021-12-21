namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.App_GlobalResources;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services.Impl;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.Habanero;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.Core.PPLiveCasino;
    using Fanex.Result.Core.SportsLottery;
    using Fanex.Result.Core.ThirdParty;
    using Fanex.Result.Core.ThirdParty.Models;
    using Fanex.Result.Core.VGaming;
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
        IRequestHandler<CGResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<VGamingResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<AdvantPlayResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<AdvantPlayMiniResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<BBINResultQuery, ThirdPartyProductViewModel>
    {
        private readonly ProductResultServiceFactory serviceFactory;
        private readonly ICacheRefService cacheRefService;
        private readonly IMaxGameResult maxGameService;
        private readonly ISportsLotteryResult sportsLotteryResult;
        private readonly IPPLiveCasinoResult ppLiveCasinoResult;
        private readonly IHabaneroResult habaneroResult;
        private readonly BrowserHelper browserHelper;
        private readonly ICGResult cgResult;
        private readonly IVGamingResult vGamingResultService;
        private readonly IAdvantPlayResult advantPlayResult;
        private readonly IAdvantPlayMiniResult advantPlayMiniResult;
        private readonly IBBINResult bbinResult;

        public ThirdPartyResultHandler(
            ProductResultServiceFactory serviceFactory,
            ICacheRefService cacheRefService,
            IMaxGameResult maxGameService,
            ISportsLotteryResult sportsLotteryResult,
            IPPLiveCasinoResult ppLiveCasinoResult,
            IHabaneroResult habaneroResult,
            ICGResult cgResult,
            IVGamingResult vGamingResult,
            IAdvantPlayResult advantPlayResult,
            IAdvantPlayMiniResult advantPlayMiniResult,
            IBBINResult bbinResult,
            BrowserHelper browserHelper)
        {
            this.serviceFactory = serviceFactory;
            this.cacheRefService = cacheRefService;
            this.maxGameService = maxGameService;
            this.sportsLotteryResult = sportsLotteryResult;
            this.ppLiveCasinoResult = ppLiveCasinoResult;
            this.habaneroResult = habaneroResult;
            this.cgResult = cgResult;
            this.advantPlayResult = advantPlayResult;
            this.advantPlayMiniResult = advantPlayMiniResult;
            this.browserHelper = browserHelper;
            this.vGamingResultService = vGamingResult;
            this.bbinResult = bbinResult;
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

        public ThirdPartyResultViewModel Handle(VGamingResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = vGamingResultService.GetResult(message.CustId.ToString(), message.GameRoundId, message.GameId, message.SiteId, message.SportId, message.CurrencyName, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }

        public ThirdPartyResultViewModel Handle(AdvantPlayResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = advantPlayResult.GetResult(message.CustId.ToString(), message.GameId, message.GameCode, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }

        public ThirdPartyResultViewModel Handle(AdvantPlayMiniResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = advantPlayMiniResult.GetResult(message.CustId.ToString(), message.GameId, message.GameCode, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(string.Format(Resources.ResultPopupTitle, productName), new SuccessResult(result));
        }

        public ThirdPartyProductViewModel Handle(BBINResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);
            var request = new ResultRequest(message.CustId, message.TransId3rd, message.GameId3rd, message.CurrencyId, message.Language)
            {
                SiteId = message.SiteId
            };

            var result = bbinResult.GetResultGET(request);

            return new ThirdPartyProductViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }
    }
}
