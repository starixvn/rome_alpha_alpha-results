namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class SpadeGamingResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SpadeGamingResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
