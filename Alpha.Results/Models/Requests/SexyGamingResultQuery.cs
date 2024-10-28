namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class SexyGamingResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public SexyGamingResultQuery(IUserSession userSession) : base(userSession)
        { }

        public string Site { get; set; }
    }
}