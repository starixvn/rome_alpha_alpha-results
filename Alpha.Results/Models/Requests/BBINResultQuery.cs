namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;
    using Sunplus.Agent.Model.Entities;

    public class BBINResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
        public BBINResultQuery(IUserSession userSession) : base(userSession)
        { }

        
    }

    public class Result3rdQuery : BaseQuery
    {
        public Result3rdQuery(IUserSession userSession) : base(userSession)
        {
            IsDarkMode = false;
        }

        public bool IsDarkMode { get; }

        public int CustId { get; set; }

        public int ProductId { get; set; }

        public string SiteId { get; set; }

        public string TransId3rd { get; set; }

        public string GameId3rd { get; set; }

        public int CurrencyId { get; set; }

        public int BetType { get; set; }

        public string EndTime { get; set; }

    }
}
