namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class RNGWarResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public RNGWarResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
