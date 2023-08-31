using Alpha.Results.Site.Models.Views;
using AlphaPlus.User.Models;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class VirtualGamesResultQuery : KenoLotteryTableGameResultQuery, IRequest<VirtualGamesResultViewModel>
    {
        public VirtualGamesResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}