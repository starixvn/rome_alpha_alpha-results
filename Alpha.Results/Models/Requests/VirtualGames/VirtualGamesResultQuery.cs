using Alpha.Results.Site.Models.Views;
using MediatR;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesResultQuery : KenoLotteryTableGameResultQuery, IRequest<VirtualGamesResultViewModel>
    {
        public VirtualGamesResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}