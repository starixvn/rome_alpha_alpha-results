namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class MaxGameResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MaxGameResultQuery(IUserSession userSession) : base(userSession)
        { }        
    }
}
