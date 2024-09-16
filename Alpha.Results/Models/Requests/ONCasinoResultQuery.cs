namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class ONCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public ONCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}