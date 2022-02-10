namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class CGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public CGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
