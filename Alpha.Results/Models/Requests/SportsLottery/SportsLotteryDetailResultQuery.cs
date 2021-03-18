using Fanex.Result.ThirdParty.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class SportsLotteryDetailResultQuery : IRequest<ThirdPartyResultViewModel>
    {
        public string CustId { get; set; }

        public string Language { get; set; }

        public string TransId3rd { get; set; }

        public int ProductId { get; set; }
    }
}