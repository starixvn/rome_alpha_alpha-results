namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using Criteria;
    using DataAccesses;
    using Fanex.Result.Core.Racing.DTO;

    public class VirtualRacingResultDataAccess : IVirtualRacingResultDataAccess
    {
        /// <summary>
        /// Get racing result.
        /// </summary>
        /// <param name="criteria">The criterion.</param>
        /// <returns>The racing data.</returns>
        public IList<Racing> GetVirtualRacingResults(GetVirtualRacingResultCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var result = new List<Racing>();
            using (var db = ObjectDbFactory.CreateInstance(criteria.GetSettingKey()))
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

        public IList<Racing> GetVirtualRacingResultDetails(GetRacingResultDetailsCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            var result = new List<Racing>();

            using (var db = ObjectDbFactory.CreateInstance(criteria.GetSettingKey()))
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
