using Alpha.Results.Site.Models.Views;
using AlphaPlus.User.Models;
using MediatR;

namespace Alpha.Results.Site.Models.Requests
{
    public class SportsLotteryDetailResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SportsLotteryDetailResultQuery(IUserSession userSession) : base(userSession)
        {
        }
    }
}