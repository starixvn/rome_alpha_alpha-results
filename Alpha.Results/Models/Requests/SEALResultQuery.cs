namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class SEALResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SEALResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
