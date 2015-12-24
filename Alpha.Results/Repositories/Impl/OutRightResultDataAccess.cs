namespace Alpha.Results.Repositories.Impl.Result
{
    using Fanex.Data;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Fanex.Result.Core.Sportsbook.DTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The class OutRightResultDataAccess.
    /// </summary>
    public class OutRightResultDataAccess : IOutRightResultDataAccess
    {
        /// <summary>
        /// Get Out Right result.
        /// </summary>
        /// <param name="criteria">The criterion.</param>
        /// <returns>The Out Right data.</returns>
        public IList<OutRight> GetOutRightResult(GetOutRightResultCriteria criteria)
        {
            var result = new List<OutRight>();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        result.Add(new OutRight
                        {
                            EventDate = reader["eventdate"] != DBNull.Value ? DateTime.Parse(reader["eventdate"].ToString()) : DateTime.MinValue,
                            SportType = reader["sporttype"] != DBNull.Value ? int.Parse(reader["sporttype"].ToString()) : 0,
                            LeagueId = reader["leagueid"] != DBNull.Value ? int.Parse(reader["leagueid"].ToString()) : 0,
                            TeamId = reader["teamid"] != DBNull.Value ? int.Parse(reader["teamid"].ToString()) : 0,
                            Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                        });
                    }
                }
            }

            return result;
        }
    }
}