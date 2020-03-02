using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesDetailResultQuery : IRequest<string>
    {
        public string Language { get; set; }

        public string GameId { get; set; }
    }
}