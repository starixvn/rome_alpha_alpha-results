namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class KenoResultQuery : KenoLotteryTableGameResultQuery, IRequest<KenoResultViewModel>
    {
        public KenoResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}
