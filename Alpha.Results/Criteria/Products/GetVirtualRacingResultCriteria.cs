namespace Alpha.Results.Site.Criteria
{
    using System;
    using Fanex.Data.Repository;
    using Sunplus.Agent.Model.BL.Definitions;

    /// <summary>
    /// The criteria GetVirtualRacingResultCriteria.
    /// </summary>
    public class GetVirtualRacingResultCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public int LeagueId { get; set; }

        public int SportType { get; set; }

        public bool IsShowAll
        {
            get
            {
#pragma warning disable CS0618 // Type or member is obsolete
                return AppSettings.LocalTest;
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }

        public override string GetSettingKey()
        {
            return "Age_Result_VSRaceSelByMeeting";
        }

        public override bool IsValid()
        {
            return FromDate > DateTime.MinValue && SportType > 0;
        }
    }
}
