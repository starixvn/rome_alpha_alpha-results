namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;

    public class GetBitcoinResultDetailsCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_BetList_Match3rdResultSel";
        }

        public override bool IsValid()
        {
            return MatchId > 0;
        }
    }
}