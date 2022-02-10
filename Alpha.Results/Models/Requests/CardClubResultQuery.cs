namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class CardClubResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public CardClubResultQuery(IUserSession userSession) : base(userSession)
        { }
    }
}
