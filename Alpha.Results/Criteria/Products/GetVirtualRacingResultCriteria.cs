namespace Alpha.Results.Site.Criteria
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetVirtualRacingResultCriteria.
    /// </summary>
    public class GetVirtualRacingResultCriteria : CriteriaBase
    {
        public DateTime MoveBetsDay { get; set; }

        public DateTime EventDate { get; set; }

        public int LeagueId { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey()
        {
            return "Age_Result_RaceSelByLeague";
        }

        public override bool IsValid()
        {
            return EventDate > DateTime.MinValue && SportType > 0;
        }
    }
}
