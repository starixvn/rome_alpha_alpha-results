namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class KenoResultQuery : KenoLotteryTableGameResultQuery, IRequest<KenoResultViewModel>
    {
        public KenoResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}
