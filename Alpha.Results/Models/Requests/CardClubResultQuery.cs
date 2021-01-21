namespace Alpha.Results.Site.Models.Requests
{
    using System.Diagnostics.CodeAnalysis;
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class CardClubResultQuery : IRequest<ThirdPartyProductViewModel>
    {
        public string CustId { get; set; }

        public string GameTypeId { get; set; }

        public string TransId3rd { get; set; }

        public int SportTypeId { get; set; }

        public string Language { get; set; }
    }
}
