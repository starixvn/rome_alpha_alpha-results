namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class MGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
