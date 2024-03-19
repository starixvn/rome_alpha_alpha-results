namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class UUSlotsResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public UUSlotsResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}