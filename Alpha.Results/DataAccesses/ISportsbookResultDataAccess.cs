namespace Alpha.Results.Site.DataAccesses
{
    using System.Collections.Generic;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.Models.Requests;
    using Fanex.Result.Core.Sportsbook.DTO;

    /// <summary>
    /// The interface ISportsBookResultDataAccess.
    /// </summary>
    public interface ISportsbookResultDataAccess
    {
        IList<Sportsbook> GetSportbookResults(GetSportsbookResultCriteria criteria);

        List<Sportsbook> GetScoreInformation(NormalResultDetailsQuery request);

        Sportsbook GetBetBuilderInformation(GetBetBuidlerResultDetailsCriteria criteria);
    }
}