namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Racing.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IVirtualRacingResultDataAccess.
    /// </summary>
    public interface IVirtualRacingResultDataAccess
    {
        IList<Racing> GetVirtualRacingResult(GetVirtualRacingResultCriteria criteria);
    }
}