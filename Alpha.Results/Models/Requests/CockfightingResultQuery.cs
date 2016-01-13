namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;
    using Views;

    public class CockfightingResultQuery : IRequest<CockfightingResultViewModel>
    {
        public int CustomerId { get; set; }

        public int SiteId { get; set; }

        public bool? IsKeepAlive { get; set; }

        public string LanguageKey { get; set; }
    }
}