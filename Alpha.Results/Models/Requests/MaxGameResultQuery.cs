namespace Alpha.Results.Site.Models.Requests
{
    using Fanex.Result.ThirdParty.Models.Views;
    using MediatR;

    public class MaxGameResultQuery : IRequest<ThirdPartyResultViewModel>
    {
        public string CustId { get; set; }

        public string TransId3rd { get; set; }

        public int BetType { get; set; }

        public string EndTime { get; set; }

        public string SiteId { get; set; }

        public string Language { get; set; }

        public int ProductId { get; set; }
    }
}
