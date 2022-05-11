using Alpha.Results.Site.Models.Views;
using MediatR;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesDetailResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public VirtualGamesDetailResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}