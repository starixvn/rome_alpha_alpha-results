namespace Alpha.Results.Site.Models.Requests
{
    using Fanex.Result.ThirdParty.Models.Requests;
    using Fanex.Result.ThirdParty.Models.Views;
    using MediatR;

    public class VGamingResultQuery : ThirdPartyResultBaseQuery, IRequest<ThirdPartyResultViewModel>
    {
        public string CurrencyName { get; set; }

        public string GameRoundId { get; set; }

        public int SportId { get; set; }
    }
}
