namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class CGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public CGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
