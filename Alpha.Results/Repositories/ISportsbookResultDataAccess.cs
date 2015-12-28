namespace Alpha.Results.Repositories
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;

    /// <summary>
    /// The interface ISportsBookResultDataAccess.
    /// </summary>
    public interface ISportsbookResultDataAccess
    {
        IList<Sportsbook> GetSportbookResults(GetSportsbookResultCriteria criteria);

        List<Sportsbook> GetScoreInformation(ref GetSportsbookResultDetailsCriteria criteria);
    }
}