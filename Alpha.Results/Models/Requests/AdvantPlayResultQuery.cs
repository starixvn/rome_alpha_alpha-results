namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class AdvantPlayResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public AdvantPlayResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
