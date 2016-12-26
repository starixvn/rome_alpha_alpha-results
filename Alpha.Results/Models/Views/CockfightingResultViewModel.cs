namespace Alpha.Results.Site.Models.Views
{
    using System.Diagnostics.CodeAnalysis;

    public class CockfightingResultViewModel
    {
        public bool IsSuccess { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Reviewed")]
        public string Url { get; set; }
    }
}