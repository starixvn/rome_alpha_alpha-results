namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IParlayPopupResultDataAccess.
    /// </summary>
    public interface IParlayPopupResultDataAccess
    {
        IList<Parlay> GetParlayResult(GetParlayPopupResultCriteria criteria);
    }
}