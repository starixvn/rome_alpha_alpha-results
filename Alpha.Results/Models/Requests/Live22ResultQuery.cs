namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class Live22ResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public Live22ResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}