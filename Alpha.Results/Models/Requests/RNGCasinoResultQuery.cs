namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class RNGCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public RNGCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
