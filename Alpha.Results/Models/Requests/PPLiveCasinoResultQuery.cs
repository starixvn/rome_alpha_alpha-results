namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class PPLiveCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PPLiveCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
