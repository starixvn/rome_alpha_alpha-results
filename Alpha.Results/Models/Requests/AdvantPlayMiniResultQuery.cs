namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class AdvantPlayMiniResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public AdvantPlayMiniResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
