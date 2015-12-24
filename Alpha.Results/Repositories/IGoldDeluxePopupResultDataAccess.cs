namespace Alpha.Results.Repositories
{
    using Alpha.Results.Criteria;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using System.Collections.Generic;

    public interface IGoldDeluxePopupResultDataAccess
    {
        IList<GoldDeluxe> GetGoldDeluxePopupResult(GetGoldDeluxePopupResultCriteria criteria);
    }
}