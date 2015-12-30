namespace Alpha.Results.Site.DataAccesses.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Alpha.Results.Site.Criteria;
    using Alpha.Results.Site.DataAccesses;
    using Fanex.Data;
    using Fanex.Result.Core.Racing.DTO;

    public class RacingResultDataAccess : IRacingResultDataAccess
    {
        /// <summary>
        /// Get racing result.
        /// </summary>
        /// <param name="criteria">The criterion.</param>
        /// <returns>The racing data.</returns>
        public IList<Racing> GetRacingResults(GetRacingResultCriteria criteria)
        {
            var result = new List<Racing>();
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        result.Add(BindRacing(reader));
                    }
                }
            }

            return result;
        }

        public IList<Racing> GetRacingResultDetails(GetRacingResultDetailsCriteria criteria)
        {
            var result = new List<Racing>();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        result.Add(BindRacing(reader));
                    }
                }
            }

            return result;
        }

        internal static Racing BindRacing(IDataReader reader)
        {
            return new Racing
            {
                LeagueId = reader["meetingid"] != DBNull.Value ? int.Parse(reader["meetingid"].ToString()) : 0,
                EngineId = reader["HorseId"] != DBNull.Value ? reader["HorseId"].ToString() : string.Empty,
                EngineNo = reader["HorseNo"] != DBNull.Value ? reader["HorseNo"].ToString() : string.Empty,
                IsFavor = reader["IsFavor"] != DBNull.Value && reader["IsFavor"].ToString().Equals("1") ? true : false,
                IsSCR = reader["IsSCR"] != DBNull.Value && reader["IsSCR"].ToString().Equals("1") ? true : false,
                Place = reader["place"] != DBNull.Value ? int.Parse(reader["place"].ToString()) : 0,
                PlaceOdds = reader["placeodds"] != DBNull.Value ? decimal.Parse(reader["placeodds"].ToString()) : 0,
                WinOdds = reader["odds"] != DBNull.Value ? decimal.Parse(reader["odds"].ToString()) : 0,
                RaceName = reader["racename"] != DBNull.Value ? int.Parse(reader["racename"].ToString()) : 0,
                KickOffTime = reader["kickofftime"] != DBNull.Value ? DateTime.Parse(reader["kickofftime"].ToString()) : DateTime.MinValue,
                Favourite = reader["IsFavor"] != DBNull.Value ? reader["IsFavor"].ToString() : string.Empty,
                RowCount = reader["rowcount"] != DBNull.Value ? int.Parse(reader["rowcount"].ToString()) : 0,
                SCROfMatch = GetSRCValue(reader),
                TFOfMatch = reader["TF"] != DBNull.Value ? reader["TF"].ToString() : string.Empty
            };
        }

        /// <summary>
        /// Gets the source value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The value of SRC.</returns>
        internal static string GetSRCValue(IDataReader reader)
        {
            if (reader["SCR"] != DBNull.Value)
            {
                string value = reader["SCR"].ToString();

                if (value.EndsWith(","))
                {
                    value = value.Remove(value.Length - 1);
                }

                return value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}