using Alpha.Results.Site.Models.Views;
using AlphaPlus.User.Models;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class Soccer5ResultQuery : Result3rdQuery, IRequest<LinkedGamesViewModel>
    {
        public Soccer5ResultQuery(IUserSession userSession) : base(userSession)
        {
        }

        public string MatchId { get; set; }

        public string Balls { get; set; }

        public int BetTypeId { get; set; }

        public int SportTypeId { get; set; }
    }
}