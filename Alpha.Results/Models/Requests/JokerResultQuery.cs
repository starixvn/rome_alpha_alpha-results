namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class JokerResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public JokerResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
