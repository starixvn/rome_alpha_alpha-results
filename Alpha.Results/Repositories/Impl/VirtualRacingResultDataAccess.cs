namespace Alpha.Results.Repositories.Impl.Result
{
    using System.Collections.Generic;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Fanex.Data;
    using Fanex.Result.Core.Racing.DTO;

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
                        result.Add(RacingResultDataAccess.BindRacing(reader));
                    }
                }
            }

            return result;
        }

        public IList<Racing> GetVirtualRacingPopupResult(GetRacingPopupResultCriteria criteria)
        {
            var result = new List<Racing>();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        result.Add(RacingResultDataAccess.BindRacing(reader));
                    }
                }
            }

            return result;
        }
    }
}