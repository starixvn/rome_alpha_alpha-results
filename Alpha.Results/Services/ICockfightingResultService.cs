namespace Alpha.Results.Site.Services
{
    using System.Diagnostics.CodeAnalysis;
    using Alpha.Results.Site.Models.Requests;

    public interface ICockfightingResultService
    {
        [SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings", Justification = "Reviewed")]
        string GetResultUrl(CockfightingResultQuery request);
    }
}