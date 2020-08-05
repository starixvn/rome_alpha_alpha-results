namespace Alpha.Results.Site.Models.Requests
{
    using System.Diagnostics.CodeAnalysis;
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class SabaClubResultQuery : IRequest<SabaClubViewModel>
    {
        public string CustId { get; set; }

        public string GameId { get; set; }

        public string GameRoundId { get; set; }

        public int SportId { get; set; }

        public string SiteId { get; set; }

        public string Language { get; set; }
    }
}
