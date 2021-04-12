namespace Alpha.Results.Site.Models.Requests
{
    using Fanex.Result.ThirdParty.Models.Views;
    using MediatR;

    public class PPLiveCasinoResultQuery : IRequest<ThirdPartyResultViewModel>
    {
        public string CustId { get; set; }

        public string GameId3rd { get; set; }

        public int BetType { get; set; }

        public string Language { get; set; }

        public int ProductId { get; set; }
    }
}
