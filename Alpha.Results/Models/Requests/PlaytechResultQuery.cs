namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class PlaytechResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PlaytechResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}