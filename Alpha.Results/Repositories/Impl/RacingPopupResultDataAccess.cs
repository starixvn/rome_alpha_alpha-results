namespace Alpha.Results.Services.Impl.Result
{
    using Fanex.Data;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories.Impl.Result;
    using Alpha.Results.Repositories;
    using Fanex.Result.Core.Racing.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The class RacingPopupResultDataAccess.
    /// </summary>
    public class RacingPopupResultDataAccess : IRacingPopupResultDataAccess
    {
        /// <summary>
        /// Get racing POPUP result.
        /// </summary>
        /// <param name="criteria">The criterion.</param>
        /// <returns>The racing POPUP data.</returns>
        public IList<Racing> GetRacingPopupResult(GetRacingPopupResultCriteria criteria)
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