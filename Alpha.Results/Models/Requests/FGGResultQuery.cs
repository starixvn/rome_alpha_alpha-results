namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class FGGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public FGGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
