namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class FunkyGamesResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public FunkyGamesResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
