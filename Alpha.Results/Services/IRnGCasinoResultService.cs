namespace Alpha.Results.Site.Services
{
    using Models.HandHistory;
    using Models.Requests;

    public interface IRNGCasinoResultService
    {
        HandHistoryModel GetResult(RNGCasinoResultQuery request);
    }
}
