namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface ISportsBookResultDataAccess.
    /// </summary>
    public interface ISportsbookResultDataAccess
    {
        IList<Sportsbook> GetSportbookResult(GetSportsbookResultCriteria criteria);
    }
}