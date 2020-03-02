using Alpha.Results.Site.Models.Views;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesResultQuery : IRequest<string>
    {
        public string Language { get; set; }
    }
}