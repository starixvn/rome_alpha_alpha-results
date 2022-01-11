namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class RNGWarResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public RNGWarResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
