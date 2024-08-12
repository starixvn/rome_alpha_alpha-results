namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetParlayPopupResultCriteria.
    /// </summary>
    public class GetParlay3rdResultCriteria : CriteriaBase
    {
        public long RefNo { get; set; }

        public override string GetSettingKey()
            => "Age_BetList_SelMatch3rdResultParlay";

        public override bool IsValid() => RefNo > 0;
    }
}