namespace Alpha.Results.Criteria
{
    using System;
    using Fanex.Data.Repository;

    public class GetResultLeaguesByDateCriteria : CriteriaBase
    {
        public string EventDate { get; set; }

        public int SportId { get; set; }

        public string Language { get; set; }

        public override string GetSettingKey()
        {
            return "Age_Result_LeagueSelByDate";
        }
    }
}