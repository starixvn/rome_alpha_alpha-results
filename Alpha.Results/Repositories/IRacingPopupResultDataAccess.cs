namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Racing.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IRacingPopupResultDataAccess.
    /// </summary>
    public interface IRacingPopupResultDataAccess
    {
        IList<Racing> GetRacingPopupResult(GetRacingPopupResultCriteria criteria);
    }
}