namespace Alpha.Results.Site.Handlers
{
    using MediatR;
    using Models.Requests;
    using Models.Views;
    using System;

    public class KenoResultHandler :
        IRequestHandler<KenoResultQuery, KenoResultViewModel>
    {
        public KenoResultViewModel Handle(KenoResultQuery message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "KenoResultQuery cannot be null");
            }

            var resultUrl = $"{message.RootUrl}game/keno/kenoresult/resultdetail?date=" 
                + DateTime.Today.ToString("yyyyMMdd")
                + $"&language={message.LanguageKey}&customerid={message.CustId}";

            var extendTokenUrl = $"{message.RootUrl}game/keno/kenoresult/extendtoken?userid={message.CustId}";

            return new KenoResultViewModel
            {
                ResultUrl = resultUrl,
                ExtendTokenUrl = extendTokenUrl
            };
        }
    }
}