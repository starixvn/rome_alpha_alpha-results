namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class MacauGamesResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MacauGamesResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
