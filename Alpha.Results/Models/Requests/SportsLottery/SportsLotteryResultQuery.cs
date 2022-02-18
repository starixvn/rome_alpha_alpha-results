namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class SportsLotteryResultQuery : Result3rdQuery, IRequest<SportsLotteryResultViewModel>
    {
        public SportsLotteryResultQuery(IUserSession userSession) : base(userSession)
        {
        }
    }
}