namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class HabaneroResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public HabaneroResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
