namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.NumberGame.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface INumberGamePopupResultDataAccess.
    /// </summary>
    public interface INumberGamePopupResultDataAccess
    {
        IList<NumberGame> GetNumberGamePopupResult(GetNumberGamePopupResultCriteria criteria);
    }
}