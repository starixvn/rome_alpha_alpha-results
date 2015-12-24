namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetNumberGamePopupResultCriteria.
    /// </summary>
    public class GetNumberGamePopupResultCriteria : CriteriaBase
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