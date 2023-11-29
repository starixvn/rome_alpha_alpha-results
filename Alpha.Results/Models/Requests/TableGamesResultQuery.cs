namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class TableGamesResultQuery : KenoLotteryTableGameResultQuery, IRequest<TableGamesResultViewModel>
    {
        public TableGamesResultQuery(IUserSession userSession) : base(userSession)
        {

        }
    }
}
