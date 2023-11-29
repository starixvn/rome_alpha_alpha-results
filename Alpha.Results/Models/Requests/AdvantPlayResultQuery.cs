namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class AdvantPlayResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public AdvantPlayResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
