namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class CardClubResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public CardClubResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
