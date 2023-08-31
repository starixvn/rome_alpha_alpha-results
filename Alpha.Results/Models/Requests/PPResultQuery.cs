namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class PPResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PPResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
