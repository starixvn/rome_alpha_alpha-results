namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface ISportsBookPopupResultDataAccess.
    /// </summary>
    public interface ISportsbookPopupResultDataAccess
    {
        List<Sportsbook> GetScoreInformation(ref GetSportsbookPopupResultCriteria criteria);
    }
}