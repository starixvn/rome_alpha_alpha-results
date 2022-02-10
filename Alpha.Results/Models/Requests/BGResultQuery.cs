namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class BGResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public BGResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
