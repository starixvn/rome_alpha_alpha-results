using Alpha.Results.Site.Models.Views;
using MediatR;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Models.Requests
{
    public class SportsLotteryDetailResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SportsLotteryDetailResultQuery(IUserSession userSession) : base(userSession)
        {
        }
    }
}