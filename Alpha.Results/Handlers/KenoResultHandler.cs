namespace Alpha.Results.Site.Handlers
{
    using System;
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using Sunplus.Agent.Model.Definitions;

    public class KenoResultHandler :
        IRequestHandler<KenoResultQuery, KenoResultViewModel>
    {
        public KenoResultViewModel Handle(KenoResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "KenoResultQuery cannot be null");
            }

            var resultUrl = string.Format(
                "{0}game/keno/kenoresult/resultdetail?date={1}&language={2}&customerid={3}&custLevelId={4}&productId={5}",
                message.RootUrl,
                DateTime.Today.ToString("yyyyMMdd"),
                message.LanguageKey,
                message.CustId,
                message.CustLevelId,
                ProductIdConstants.Keno);

            var extendTokenUrl = $"{message.RootUrl}game/keno/kenoresult/extendtoken?userid={message.CustId}&productId={ProductIdConstants.Keno}";

            return new KenoResultViewModel
            {
                ResultUrl = resultUrl,
                ExtendTokenUrl = extendTokenUrl
            };
        }
    }
}