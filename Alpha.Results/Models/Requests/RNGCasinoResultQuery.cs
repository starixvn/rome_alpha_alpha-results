namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class RNGCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public RNGCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
