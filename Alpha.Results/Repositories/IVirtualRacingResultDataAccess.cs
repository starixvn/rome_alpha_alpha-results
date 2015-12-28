namespace Alpha.Results.Repositories
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.Racing.DTO;

    /// <summary>
    /// The interface IVirtualRacingResultDataAccess.
    /// </summary>
    public interface IVirtualRacingResultDataAccess
    {
        IList<Racing> GetVirtualRacingResult(GetVirtualRacingResultCriteria criteria);

        IList<Racing> GetVirtualRacingPopupResult(GetRacingPopupResultCriteria criteria);
    }
}