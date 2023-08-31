namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class FGGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public FGGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
