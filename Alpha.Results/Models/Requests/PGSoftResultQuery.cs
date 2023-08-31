namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class PGSoftResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PGSoftResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
