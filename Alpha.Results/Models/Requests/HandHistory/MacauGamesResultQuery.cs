namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;
    using Views;

    public class MacauGamesResultQuery : HandHistoryResultBaseQuery, IRequest<HandHistoryResultViewModel>
    {
    }
}
