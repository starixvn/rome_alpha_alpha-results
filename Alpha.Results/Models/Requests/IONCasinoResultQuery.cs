namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class IONCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public IONCasinoResultQuery(IUserSession userSession) : base(userSession)
        {
        }

    }
}
