namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class MGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
