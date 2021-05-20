namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class LotteryResultQuery : KenoLotteryTableGameResultQuery, IRequest<LotteryResultViewModel>
    {
        public LotteryResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}