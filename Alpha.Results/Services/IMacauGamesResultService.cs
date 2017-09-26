namespace Alpha.Results.Site.Services
{
    using Models.HandHistory;
    using Models.Requests;

    public interface IMacauGamesResultService
    {
        HandHistoryModel GetResult(MacauGamesResultQuery request);
    }
}
