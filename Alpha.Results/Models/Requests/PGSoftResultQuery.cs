namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class PGSoftResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PGSoftResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
