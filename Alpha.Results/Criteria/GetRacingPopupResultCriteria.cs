namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetRacingPopupResultCriteria.
    /// </summary>
    public class GetRacingPopupResultCriteria : CriteriaBase
    {
        [SpParam(SqlParamName = "MatchID")]
        public int MatchId { get; set; }

        public int? RaceNo { get; set; }

        public override string GetSettingKey()
        {
            return "Age_BetList_SelMatchResult2";
        }
    }
}