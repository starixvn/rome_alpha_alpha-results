namespace Alpha.Results.Site.DataAccesses
{
    using System.Collections.Generic;
    using Alpha.Results.Site.Criteria;
    using Fanex.Result.Core.Racing.DTO;

    /// <summary>
    /// The interface IRacingResultDataAccess.
    /// </summary>
    public interface IRacingResultDataAccess
    {
        IList<Racing> GetRacingResults(GetRacingResultCriteria criteria);

        IList<Racing> GetRacingResultDetails(GetRacingResultDetailsCriteria criteria);
    }
}