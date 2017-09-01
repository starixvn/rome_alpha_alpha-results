namespace Alpha.Results.Site.RNGCasino.Services
{
    using Criteria;
    using Models.RNGCasino.HandHistory;

    public interface IRnGCasinoService
    {
        HandHistoryModel GetHandHistory(GetRNGCasinoResultCriteria criteria);

        HandHistoryModel GetVoidbridgeResult(GetVoidbridgeResultCriteria criteria, string language);

        HandHistoryModel GetResultCriteria(GetResultCriteria criteria, string language);
    }
}
