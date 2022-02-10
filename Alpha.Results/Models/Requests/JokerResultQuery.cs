namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class JokerResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public JokerResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
