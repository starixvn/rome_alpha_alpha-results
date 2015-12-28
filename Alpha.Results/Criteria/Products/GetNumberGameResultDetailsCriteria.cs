namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetNumberGamePopupResultCriteria.
    /// </summary>
    public class GetNumberGameResultDetailsCriteria : CriteriaBase
    {
        public int MatchID { get; set; }

        public override string GetSettingKey()
        {
            return "Age_BetList_SelMatchResultNumberGame";
        }

        public override bool IsValid()
        {
            return MatchID > 0;
        }
    }
}