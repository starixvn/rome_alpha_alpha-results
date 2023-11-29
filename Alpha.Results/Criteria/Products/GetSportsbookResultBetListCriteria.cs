namespace Alpha.Results.Site.Criteria
{
    using System.Collections;

    /// <summary>
    /// The criteria GetSportsBookPopupResultCriteria.
    /// </summary>
    public class GetSportsbookResultBetListCriteria : GetSportsbookResultDetailsCriteria
    {
        public override string GetSettingKey()
            => "Age_BetList_SelMatchResult";

        public int BetType { get; set; }

        public long BetId { get; set; }

        public string Transdesc { get; set; }
       
    }
}