namespace Alpha.Results.Site.Handlers
{
    using Alpha.Results.Site.App_GlobalResources;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Models.Views;
    using Alpha.Results.Site.Services.Impl;
    using Alpha.Utilities.IP;
    using Fanex.Common.Helper;
    using Fanex.Result.Core.ThirdParty;
    using Fanex.Result.Core.ThirdParty.Models;
    using Fanex.Result.Core.VGaming;
    using Fanex.Result.ThirdParty.Services;
    using MediatR;
    using Models.Requests;
    using Services;
    using Sunplus.Agent.Model.Common;

    public class ThirdPartyResultHandler :
        IRequestHandler<FishingWorldResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<MaxGameResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<SportsLotteryDetailResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<PPLiveCasinoResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<HabaneroResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<CGResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<VGamingResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<AdvantPlayResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<AdvantPlayMiniResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<BBINResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<RNGCasinoResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<MacauGamesResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<SpadeGamingResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<RNGWarResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<IONCasinoResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<PGSoftResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<JokerResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<LinkedGamesResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<BGResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<CardClubResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<PPResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<FGGResultQuery, ThirdPartyProductViewModel>,
        IRequestHandler<VirtualGamesDetailResultQuery, ThirdPartyProductViewModel>
    {
        private readonly ICacheRefService cacheRefService;
        private readonly IMaxGameResult maxGameService;
        private readonly ISportsLotteryDetailResult sportsLotteryResult;
        private readonly IPPLiveCasinoResult ppLiveCasinoResult;
        private readonly IHabaneroResult habaneroResult;
        private readonly BrowserHelper browserHelper;
        private readonly ICGResult cgResult;
        private readonly IVGamingResult vGamingResultService;
        private readonly IAdvantPlayResult advantPlayResult;
        private readonly IAdvantPlayMiniResult advantPlayMiniResult;
        private readonly IRNGCasinoResult rngCasinoResult;
        private readonly IMacauGamesResult macauGamesResult;
        private readonly ISpadeGamingResult spadeGamingResult;
        private readonly IRNGWarResult rngWarResult;
        private readonly IIONCasinoResult ionCasinoResult;
        private readonly IPGSoftResult pgSoftResult;
        private readonly IJokerResult jokerResult;
        private readonly IHappy5LinkedGamesResult linkedGamesResult;
        private readonly IBGResult bgResult;
        private readonly ICardClubResult cardClubResult;
        private readonly IPPResult ppResult;
        private readonly IBBINResult bbinResult;
        private readonly IGDGResult gdgResult;
        private readonly IFGGResult fggResult;
        private readonly IPService ipService;
        private readonly IVirtualGamesDetailResult virtualGamesResult;
        private readonly ProductResultServiceFactory serviceFactory;
        private readonly IPHelper ipHelper;

        public ThirdPartyResultHandler(
            ProductResultServiceFactory serviceFactory,
            ICacheRefService cacheRefService,
            IMaxGameResult maxGameService,
            IPPLiveCasinoResult ppLiveCasinoResult,
            IHabaneroResult habaneroResult,
            ICGResult cgResult,
            IVGamingResult vGamingResult,
            IAdvantPlayResult advantPlayResult,
            IAdvantPlayMiniResult advantPlayMiniResult,
            IBBINResult bbinResult,
            IRNGCasinoResult rngCasinoResult,
            IMacauGamesResult macauGamesResult,
            ISpadeGamingResult spadeGamingResult,
            IRNGWarResult rngWarResult,
            IIONCasinoResult ionCasinoResult,
            IPGSoftResult pgSoftResult,
            IJokerResult jokerResult,
            IHappy5LinkedGamesResult linkedGamesResult,
            IBGResult bgResult,
            ICardClubResult cardClubResult,
            IPPResult ppResult,
            IGDGResult gdgResult,
            ISportsLotteryDetailResult sportsLotteryResult,
            IFGGResult fggResult,
            IPService ipService,
            IVirtualGamesDetailResult virtualGamesResult,
            BrowserHelper browserHelper,
            IPHelper ipHelper)
        {
            this.serviceFactory = serviceFactory;
            this.cacheRefService = cacheRefService;
            this.maxGameService = maxGameService;
            this.ppLiveCasinoResult = ppLiveCasinoResult;
            this.habaneroResult = habaneroResult;
            this.cgResult = cgResult;
            this.advantPlayResult = advantPlayResult;
            this.advantPlayMiniResult = advantPlayMiniResult;
            this.browserHelper = browserHelper;
            this.vGamingResultService = vGamingResult;
            this.bbinResult = bbinResult;
            this.rngCasinoResult = rngCasinoResult;
            this.macauGamesResult = macauGamesResult;
            this.spadeGamingResult = spadeGamingResult;
            this.rngWarResult = rngWarResult;
            this.ionCasinoResult = ionCasinoResult;
            this.pgSoftResult = pgSoftResult;
            this.jokerResult = jokerResult;
            this.linkedGamesResult = linkedGamesResult;
            this.bgResult = bgResult;
            this.cardClubResult = cardClubResult;
            this.ppResult = ppResult;
            this.gdgResult = gdgResult;
            this.fggResult = fggResult;
            this.ipService = ipService;
            this.sportsLotteryResult = sportsLotteryResult;
            this.virtualGamesResult = virtualGamesResult;
            this.ipHelper = ipHelper;
        }

        public ThirdPartyProductViewModel Handle(FishingWorldResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetDetailLink(message);

            return new ThirdPartyProductViewModel(string.Format(Resources.ResultPopupTitle, productName), result.Value);
        }

        public ThirdPartyProductViewModel Handle(VirtualGamesDetailResultQuery message)
            => Handle(message, virtualGamesResult);

        public ThirdPartyProductViewModel Handle(MaxGameResultQuery message)
            => Handle(message, maxGameService);

        public ThirdPartyProductViewModel Handle(SportsLotteryDetailResultQuery message)
            => Handle(message, sportsLotteryResult);

        public ThirdPartyProductViewModel Handle(PPResultQuery message)
            => Handle(message, ppResult);

        public ThirdPartyProductViewModel Handle(PPLiveCasinoResultQuery message)
            => Handle(message, ppLiveCasinoResult);

        public ThirdPartyProductViewModel Handle(HabaneroResultQuery message)
            => Handle(message, habaneroResult);

        public ThirdPartyProductViewModel Handle(CGResultQuery message)
            => Handle(message, cgResult);

        public ThirdPartyProductViewModel Handle(VGamingResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);
            var result = vGamingResultService.GetResult(message.CustId.ToString(), message.GameRoundId, message.GameId, message.SiteId, message.SportId, message.CurrencyName, message.Language);

            return new ThirdPartyProductViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }

        public ThirdPartyProductViewModel Handle(AdvantPlayResultQuery message)
            => Handle(message, advantPlayResult);

        public ThirdPartyProductViewModel Handle(AdvantPlayMiniResultQuery message)
            => Handle(message, advantPlayMiniResult);

        public ThirdPartyProductViewModel Handle(BBINResultQuery message)
            => Handle(message, bbinResult);

        public ThirdPartyProductViewModel Handle(CardClubResultQuery message)
            => Handle(message, cardClubResult);

        public ThirdPartyProductViewModel Handle(BGResultQuery message)
            => Handle(message, bgResult);

        public ThirdPartyProductViewModel Handle(GDGResultQuery message)
            => Handle(message, gdgResult);

        public ThirdPartyProductViewModel Handle(JokerResultQuery message)
            => Handle(message, jokerResult);

        public ThirdPartyProductViewModel Handle(PGSoftResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);
            var ipInfo = ipService.GetIPInformation(ipHelper.GetClientIP());
            var request = new ResultRequest(message.CustId, message.TransId3rd, message.GameId3rd, message.CurrencyId, message.SiteId, message.Language)
            {
                IsDarkMode = message.IsDarkMode ? "1" : "0",
                Platform = browserHelper.IsMobile() ? "M" : "D",
                BetTypeId = message.BetType,
                EndTime = message.EndTime,
                Location = ipInfo != null ? ipInfo.CountryShort : string.Empty
            };

            var result = pgSoftResult.GetResultGET(request);

            return new ThirdPartyProductViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }

        public ThirdPartyProductViewModel Handle(IONCasinoResultQuery message)
            => Handle(message, ionCasinoResult);

        public ThirdPartyProductViewModel Handle(RNGWarResultQuery message)
            => Handle(message, rngWarResult);

        public ThirdPartyProductViewModel Handle(SpadeGamingResultQuery message)
            => Handle(message, spadeGamingResult);

        public ThirdPartyProductViewModel Handle(MacauGamesResultQuery message)
            => Handle(message, macauGamesResult);

        public ThirdPartyProductViewModel Handle(FGGResultQuery message)
            => Handle(message, fggResult);

        public ThirdPartyProductViewModel Handle(LinkedGamesResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");
            var title = $"{cacheRefService.GetSportName(message.SportTypeId)} - {cacheRefService.GetBetTypeName(message.BetTypeId)}";
            var request = new ResultRequest(message.CustId, message.TransId3rd, message.GameId3rd, message.CurrencyId, message.SiteId, message.Language)
            {
                IsDarkMode = message.IsDarkMode ? "1" : "0",
                Platform = browserHelper.IsMobile() ? "M" : string.Empty
            };

            var result = linkedGamesResult.GetResultGET(request);

            return new ThirdPartyProductViewModel(title, result);
        }

        public ThirdPartyProductViewModel Handle(RNGCasinoResultQuery message)
            => Handle(message, rngCasinoResult);

        private ThirdPartyProductViewModel Handle(Result3rdQuery message, IThirdPartyResult resultService)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);
            var request = new ResultRequest(message.CustId, message.TransId3rd, message.GameId3rd, message.CurrencyId, message.SiteId, message.Language)
            {
                IsDarkMode = message.IsDarkMode ? "1" : "0",
                Platform = browserHelper.IsMobile() ? "M" : "D",
                BetTypeId = message.BetType,
                EndTime = message.EndTime
            };

            var result = resultService.GetResultGET(request);

            return new ThirdPartyProductViewModel(string.Format(Resources.ResultPopupTitle, productName), result);
        }
    }
}
