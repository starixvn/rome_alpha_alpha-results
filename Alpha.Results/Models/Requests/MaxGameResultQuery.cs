namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class MaxGameResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MaxGameResultQuery(IUserSession userSession) : base(userSession)
        { }        
    }
}
