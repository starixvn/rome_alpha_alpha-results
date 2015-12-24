namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.NumberGame.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The interface INumberGameResultDataAccess.
    /// </summary>
    public interface INumberGameResultDataAccess
    {
        IList<NumberGame> GetNumberGameResult(GetNumberGameResultCriteria criteria);
    }
}