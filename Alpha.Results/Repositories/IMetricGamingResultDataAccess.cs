namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using System.Collections.Generic;

    public interface IMetricGamingResultDataAccess
    {
        List<Fanex.Result.Core.MetricGaming.DTO.MetricGaming> GetResult(GetMetricGamingResultCriteria criteria);
    }
}