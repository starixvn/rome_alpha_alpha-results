namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;
    
    public class GetBetBuidlerResultDetailsCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public int MarketId { get; set; }

        public override string GetSettingKey()
        {
            return "Age_TicketResult_BetBuilder";
        }

        public override bool IsValid()
        {
            return MatchId > 0 && MarketId > 0;
        }
    }
}