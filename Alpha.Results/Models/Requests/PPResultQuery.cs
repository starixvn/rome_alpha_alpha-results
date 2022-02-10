namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class PPResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public PPResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
