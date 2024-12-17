namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class GPILiveCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public GPILiveCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}