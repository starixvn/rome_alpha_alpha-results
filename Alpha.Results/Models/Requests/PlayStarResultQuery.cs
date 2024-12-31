namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class PlayStarResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PlayStarResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
