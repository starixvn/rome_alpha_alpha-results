namespace Alpha.Results.Repositories
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Racing.DTO;

    /// <summary>
    /// The interface IRacingResultDataAccess.
    /// </summary>
    public interface IRacingResultDataAccess
    {
        IList<Racing> GetRacingResult(GetRacingResultCriteria criteria);

        IList<Racing> GetRacingPopupResult(GetRacingPopupResultCriteria criteria);
    }
}