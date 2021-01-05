using Alpha.Results.Site.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class Happy5LinkedGamesResultQuery : IRequest<Happy5LinkedGamesViewModel>
    {
        public string Language { get; set; }

        public string CustId { get; set; }

        public string TransId3rd { get; set; }

        public int SportTypeId { get; set; }

        public int BetTypeId { get; set; }
    }
}