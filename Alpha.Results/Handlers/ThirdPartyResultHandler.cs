namespace Alpha.Results.Site.Handlers
{
    using App_GlobalResources;
    using Constants;
    using Fanex.Common.Helper;
    using Fanex.Result.ThirdParty.Models.Views;
    using Fanex.Result.ThirdParty.Services;
    using MediatR;
    using Models.Requests;
    using RemotingRef;

    public class ThirdPartyResultHandler : IRequestHandler<ThirdPartyResultQuery, ThirdPartyResultViewModel>,
        IRequestHandler<ThirdPartyPopupResultQuery,ThirdPartyResultViewModel>
    {
        private readonly ProductResultServiceFactory serviceFactory;

        public ThirdPartyResultHandler(ProductResultServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = CacheRefFactory.CacheRef.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetResultLink(message);

            return new ThirdPartyResultViewModel(productName, result);
        }

        public ThirdPartyResultViewModel Handle(ThirdPartyPopupResultQuery message)
        {
            Check.Argument.IsNotNull(message, "message");

            var productName = CacheRefFactory.CacheRef.GetProductName(message.ProductId);

            var productResultService = serviceFactory.CreateProductResultService(message.ProductId);
            var result = productResultService.GetPopupResultLink(message);

            return new ThirdPartyResultViewModel(productName, result);
        }
    }
}
