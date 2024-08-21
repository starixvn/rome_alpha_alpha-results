namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class NextspinResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public NextspinResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}