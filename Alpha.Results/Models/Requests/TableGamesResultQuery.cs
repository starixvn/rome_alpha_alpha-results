namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class TableGamesResultQuery : KenoLotteryTableGameResultQuery, IRequest<TableGamesResultViewModel>
    {
        public TableGamesResultQuery(IUserSession userSession):base(userSession)
        {

        }
    }
}
