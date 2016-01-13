namespace Alpha.Results.Site.Services
{
    using Alpha.Results.Site.Models.Requests;

    public interface ICockfightingResultService
    {
        string GetResultUrl(CockfightingResultQuery request);
    }
}