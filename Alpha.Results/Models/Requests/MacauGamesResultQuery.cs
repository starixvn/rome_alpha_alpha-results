namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class MacauGamesResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public MacauGamesResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
