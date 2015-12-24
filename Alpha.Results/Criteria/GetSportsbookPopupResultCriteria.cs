namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetSportsBookPopupResultCriteria.
    /// </summary>
    public class GetSportsbookPopupResultCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public string RaceNo { get; set; }

        [SpParam(Ignored = true)]
        public int SportType { get; set; }

        [SpParam(Ignored = true)]
        public bool IsViewDetail { get; set; }

        public int BetType { get; set; }

        public long BetId { get; set; }

        public override string GetSettingKey()
        {
            return this.IsViewDetail ? "Age_Result_MatchSelResultDetail" : "Age_BetList_SelMatchResult";
        }

        public override bool IsValid()
        {
            return this.MatchId > 0;
        }
    }
}