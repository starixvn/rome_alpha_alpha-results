namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Racing.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IRacingResultDataAccess.
    /// </summary>
    public interface IRacingResultDataAccess
    {
        IList<Racing> GetRacingResult(GetRacingResultCriteria criteria);

        IList<Racing> GetRacingPopupResult(GetRacingPopupResultCriteria criteria);
    }
}