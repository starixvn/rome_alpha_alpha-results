namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class VGamingResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public VGamingResultQuery(IUserSession userSession) : base(userSession)
        {
        }

        public string CurrencyName { get; set; }

        public string GameRoundId { get; set; }

        public string GameId { get; set; }

        public int SportId { get; set; }
    }
}
