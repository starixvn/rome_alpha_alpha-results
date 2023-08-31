namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class BGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public BGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
