namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class SabaxDResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SabaxDResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}