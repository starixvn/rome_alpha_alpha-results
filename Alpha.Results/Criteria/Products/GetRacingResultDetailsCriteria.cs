namespace Alpha.Results.Site.Criteria
{
    using System;
    using Fanex.Data;
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetRacingPopupResultCriteria.
    /// </summary>
    public class GetRacingResultDetailsCriteria : CriteriaBase
    {
        [SpParam(SqlParamName = "EventID")]
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime MoveBetsDay { get; set; }
        public DateTime BalanceUpDay { get; set; }

        public override string GetSettingKey()
            => "Age_BetList_SelRaceResult";

        public override bool IsValid()
            => EventId > 0;
    }
}