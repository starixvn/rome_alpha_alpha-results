namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class GPIResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public GPIResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
