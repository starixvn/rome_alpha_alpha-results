namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class VGamingResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public VGamingResultQuery(IUserSession userSession) : base(userSession)
        {
        }
    }
}
