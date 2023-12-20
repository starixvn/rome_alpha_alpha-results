namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class WEResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public WEResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}