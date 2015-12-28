namespace Alpha.Results.Repositories
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.NumberGame.DTO;

    /// <summary>
    /// The interface INumberGameResultDataAccess.
    /// </summary>
    public interface INumberGameResultDataAccess
    {
        IList<NumberGame> GetNumberGameResult(GetNumberGameResultCriteria criteria);

        IList<NumberGame> GetNumberGamePopupResult(GetNumberGamePopupResultCriteria criteria);
    }
}