namespace Alpha.Results.DataAccesses
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
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