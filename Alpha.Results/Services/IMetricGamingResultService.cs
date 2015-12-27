namespace Alpha.Results.Services
{
    using Alpha.Results.Criteria;

    /// <summary>
    /// Please not this service should separate into another controller.
    /// </summary>
    public interface IMetricGamingResultService
    {
        string GetResult(GetMetricGamingResultCriteria criteria);
    }
}