namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class HabaneroResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public HabaneroResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
