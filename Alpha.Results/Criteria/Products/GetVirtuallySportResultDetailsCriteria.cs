namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;

    public class GetVirtuallySportResultDetailsCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_BetList_VS5_Match3rdResultSel";
        }

        public override bool IsValid()
        {
            return MatchId > 0;
        }
    }
}