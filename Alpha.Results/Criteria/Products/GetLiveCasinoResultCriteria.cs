namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetLiveCasinoPopupResultCriteria.
    /// </summary>
    public class GetLiveCasinoResultCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public int BetType { get; set; }

        public string League { get; set; }

        public override string GetSettingKey()
        {
            return "Age_BetList_SelMatchResult";
        }

        public override bool IsValid()
        {
            return MatchId > 0 && BetType > 0;
        }
    }
}