using Alpha.Results.Site.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class Soccer5ResultQuery : IRequest<LinkedGamesViewModel>
    {
        public string Language { get; set; }

        public string MatchId { get; set; }

        public string Balls { get; set; }

        public int BetTypeId { get; set; }

        public int SportTypeId { get; set; }
    }
}