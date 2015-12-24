namespace Alpha.Results.Services.Result
{
    using Alpha.Results.Criteria;

    public interface IMetricGamingResultService
    {
        string GetResult(GetMetricGamingResultCriteria criteria);
    }
}