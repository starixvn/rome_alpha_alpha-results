namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class FastSpinResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public FastSpinResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}