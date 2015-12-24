namespace Alpha.Results.Repositories.Impl.Result
{
    using Fanex.Data;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Fanex.Result.Core.Racing.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The class VirtualRacingResultDataAccess.
    /// </summary>
    public class VirtualRacingResultDataAccess : IVirtualRacingResultDataAccess
    {
        /// <summary>
        /// Get racing result.
        /// </summary>
        /// <param name="criteria">The criterion.</param>
        /// <returns>The racing data.</returns>
        public IList<Racing> GetVirtualRacingResult(GetVirtualRacingResultCriteria criteria)
        {
            var result = new List<Racing>();
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        result.Add(BindingUtilities.BindRacing(reader));
                    }
                }
            }

            return result;
        }
    }
}