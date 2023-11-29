namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class SpadeGamingResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SpadeGamingResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
