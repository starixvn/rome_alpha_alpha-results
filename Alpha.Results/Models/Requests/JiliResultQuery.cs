namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using AlphaPlus.User.Models;
    using MediatR;


    public class JiliResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public JiliResultQuery(IUserSession userSession) : base(userSession)
        { 
        }

        public string TransDesc { get; set; }
    }
}