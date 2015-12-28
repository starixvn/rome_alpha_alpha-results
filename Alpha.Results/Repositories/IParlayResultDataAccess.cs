namespace Alpha.Results.Repositories
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;

    /// <summary>
    /// The interface IParlayPopupResultDataAccess.
    /// </summary>
    public interface IParlayResultDataAccess
    {
        IList<Parlay> GetParlayResult(GetParlayPopupResultCriteria criteria);
    }
}