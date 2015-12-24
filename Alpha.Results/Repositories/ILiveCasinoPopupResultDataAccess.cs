namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.LiveCasino.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface ILiveCasinoPopupResultDataAccess.
    /// </summary>
    public interface ILiveCasinoPopupResultDataAccess
    {
        IList<LiveCasino> GetLiveCasinoPopupResult(GetLiveCasinoPopupResultCriteria criteria);
    }
}