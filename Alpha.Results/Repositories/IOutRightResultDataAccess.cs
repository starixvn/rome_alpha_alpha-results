namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Sportsbook.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IOutRightResultDataAccess.
    /// </summary>
    public interface IOutRightResultDataAccess
    {
        IList<OutRight> GetOutRightResult(GetOutRightResultCriteria criteria);
    }
}