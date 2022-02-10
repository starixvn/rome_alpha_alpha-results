namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class AdvantPlayMiniResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public AdvantPlayMiniResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
