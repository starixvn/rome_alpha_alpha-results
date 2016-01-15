namespace Alpha.Results.Site.Models.Requests
{
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class KenoResultQuery : IRequest<KenoResultViewModel>
    {
        public int CustId { get; set; }

        public string LanguageKey { get; set; }

        public string RootUrl { get; set; }
    }
}