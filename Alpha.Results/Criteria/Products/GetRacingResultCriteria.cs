namespace Alpha.Results.Site.Criteria
{
    using System;
    using Configurations;
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetRacingResultCriteria.
    /// </summary>
    public class GetRacingResultCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public int LeagueId { get; set; }

        public int SportType { get; set; }

        public bool IsShowAll
        {
            get
            {
                return AppSettings.LocalTest;
            }
        }

        public override string GetSettingKey()
        {
            return "Age_Result_RBRaceSelByMeeting";
        }

        public override bool IsValid()
        {
            return FromDate > DateTime.MinValue && SportType > 0;
        }
    }
}
