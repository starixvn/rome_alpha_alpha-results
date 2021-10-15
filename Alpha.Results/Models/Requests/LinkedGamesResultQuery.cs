using Alpha.Results.Site.Models.Views;
using MediatR;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Models.Requests
{
    public class LinkedGamesResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public LinkedGamesResultQuery(IUserSession userSession) : base(userSession)
        { }
        
        public int SportTypeId { get; set; }

        public int BetTypeId { get; set; }
    }
}