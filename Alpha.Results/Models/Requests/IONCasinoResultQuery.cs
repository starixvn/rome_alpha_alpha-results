namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class IONCasinoResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public IONCasinoResultQuery(IUserSession userSession) : base(userSession)
        {
        }

    }
}
