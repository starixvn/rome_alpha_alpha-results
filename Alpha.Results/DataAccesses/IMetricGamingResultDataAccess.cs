namespace Alpha.Results.DataAccesses
{
    using System.Collections.Generic;
    using Criteria;
    using Fanex.Result.Core.MetricGaming.DTO;

    public interface IMetricGamingResultDataAccess
    {
        IList<MetricGaming> GetResults(GetMetricGamingResultCriteria criteria);
    }
}