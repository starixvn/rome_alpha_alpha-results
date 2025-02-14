namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;

    public class ASKMESLOTResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public ASKMESLOTResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}