namespace Alpha.Results.Site.Services
{
    using Models.HandHistory;
    using Models.Requests;

    public interface IFishingWorldResultService
    {
        HandHistoryModel GetResult(FishingWorldResultQuery request);
    }
}
