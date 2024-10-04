namespace Alpha.Results.Site.DataAccesses
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.VirtualRacing.DTO;

    /// <summary>
    /// The interface IVirtualRacingResultDataAccess.
    /// </summary>
    public interface IVirtualRacingResultDataAccess
    {
        IList<VirtualRacing> GetVirtualRacingResultDetails(ICriteria criteria);
    }
}