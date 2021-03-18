namespace Alpha.Results.Site.Models.Views
{
    using Alpha.Results.Site.App_GlobalResources;
    using System.Diagnostics.CodeAnalysis;

    public class KenoResultViewModel : BaseResultTab
    {
        public KenoResultViewModel()
        {
            ProductName = Resources.Keno;
        }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Reviewed")]
        public string ResultUrl { get; set; }

        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Reviewed")]
        public string ExtendTokenUrl { get; set; }
    }
}