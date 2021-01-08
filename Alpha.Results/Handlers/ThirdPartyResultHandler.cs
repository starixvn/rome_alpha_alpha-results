namespace Alpha.Results.Site.Handlers
{
    using Fanex.Common.Helper;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.ThirdParty.Models;
    using Fanex.Result.ThirdParty.Models.Views;
    using Fanex.Result.ThirdParty.Services;
    using MediatR;
    using Models.Requests;
    using Services;

    public class ThirdPartyResultHandler : IRequestHandler<ThirdPartyResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<ThirdPartyDetailResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<MaxGameResultQuery, ThirdPartyResultViewModel>
    {
        private readonly ProductResultServiceFactory serviceFactory;
        private readonly ICacheRefService cacheRefService;
        private readonly IMaxGameResult maxGameService;

        public ThirdPartyResultHandler(
            ProductResultServiceFactory serviceFactory,
            ICacheRefService cacheRefService,
            IMaxGameResult maxGameService)
        {
            this.serviceFactory = serviceFactory;
            this.cacheRefService = cacheRefService;
            this.maxGameService = maxGameService;
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetResultLink(message);

            return new ThirdPartyResultViewModel(productName, result);
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyDetailResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetDetailLink(message);

            return new ThirdPartyResultViewModel(productName, result);
        }

        public ThirdPartyResultViewModel Handle(MaxGameResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = cacheRefService.GetProductName(message.ProductId);

            var result = maxGameService.GetResult(message.CustId, message.TransId3rd, message.BetType, message.EndTime, message.SiteId, message.Language);

            return new ThirdPartyResultViewModel(productName, new SuccessResult(result));
        }
    }
}
