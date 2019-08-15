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
        [SpParam(SqlParamName = "MatchID")]
        public int MatchId { get; set; }

        [SpParam(Ignored = true)]
        public int? RaceNo { get; set; }

        public override string GetSettingKey()
        {
            return "Age_BetList_SelMatchResult2";
        }

        public override bool IsValid()
            => MatchId > 0;
    }
}