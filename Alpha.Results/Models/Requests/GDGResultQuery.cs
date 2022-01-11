namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class GDGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public GDGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
