using Alpha.Results.Site.Models.Views;
using AlphaPlus.User.Models;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesDetailResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public VirtualGamesDetailResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}