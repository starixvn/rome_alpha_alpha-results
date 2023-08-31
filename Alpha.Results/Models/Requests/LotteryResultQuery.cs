namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class LotteryResultQuery : KenoLotteryTableGameResultQuery, IRequest<LotteryResultViewModel>
    {
        public LotteryResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}