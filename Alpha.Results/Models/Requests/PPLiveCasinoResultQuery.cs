namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class PPLiveCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PPLiveCasinoResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
