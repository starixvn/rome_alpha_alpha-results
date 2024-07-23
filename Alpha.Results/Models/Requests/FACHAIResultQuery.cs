namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class FACHAIResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public FACHAIResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}