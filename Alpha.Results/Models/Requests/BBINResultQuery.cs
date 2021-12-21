namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class BBINResultQuery : Result3rdQuery, IRequest<ThirdPartyProductViewModel>
    {
    }

    public class Result3rdQuery
    {
        public int CustId { get; set; }

        public int ProductId { get; set; }

        public string SiteId { get; set; }

        public string TransId3rd { get; set; }

        public string GameId3rd { get; set; }

        public int CurrencyId { get; set; }

        public string Language { get; set; }
    }
}
