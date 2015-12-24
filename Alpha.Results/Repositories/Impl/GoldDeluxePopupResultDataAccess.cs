namespace Alpha.Results.Repositories.Impl.Result
{
    using Fanex.Data;
    using Alpha.Results.Criteria;
    using Alpha.Results.Repositories;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using System.Collections.Generic;
    using System.Data;

    public class GoldDeluxePopupResultDataAccess : IGoldDeluxePopupResultDataAccess
    {
        public IList<GoldDeluxe> GetGoldDeluxePopupResult(GetGoldDeluxePopupResultCriteria criteria)
        {
            int betType = criteria.BetType;
            var goldDeluxes = new List<GoldDeluxe>();

            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        goldDeluxes.Add(BindGoldDeluxe(reader, betType));
                    }
                }
            }

            return goldDeluxes;
        }

        private GoldDeluxe BindGoldDeluxe(IDataReader reader, int betType)
        {
            return new GoldDeluxe
            {
                Bettype = betType,
                Result = reader["TransDesc"].ToString()
            };
        }
    }
}