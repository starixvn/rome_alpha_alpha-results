namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class SportsLotteryResultQuery : Result3rdQuery, IRequest<SportsLotteryResultViewModel>
    {
        public SportsLotteryResultQuery(IUserSession userSession) : base(userSession)
        {
        }
    }
}