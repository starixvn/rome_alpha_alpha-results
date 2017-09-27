using System;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Models.Views;
using MediatR;
using Sunplus.Agent.Model.Definitions;

namespace Alpha.Results.Site.Handlers
{
    public class LotteryResultHandler :
         IRequestHandler<LotteryResultQuery, LotteryResultViewModel>
    {
        public LotteryResultViewModel Handle(LotteryResultQuery message)
        {
            var resultPath = string.Format(
                "{0}game/keno/kenoresult/resultdetail?date={1}&language={2}&productId={4}&customerid={3}",
                message.RootPath,
                DateTime.Today.ToString("yyyyMMdd"),
                message.LanguageKey,
                message.CustId,
                ProductIdConstants.Lottery);

            var extendTokenPath = $"{message.RootPath}game/keno/kenoresult/extendtoken?productId={ProductIdConstants.Lottery}&userid={message.CustId}";

            return new LotteryResultViewModel
            {
                ResultPath = resultPath,
                ExtendTokenPath = extendTokenPath
            };
        }
    }
}