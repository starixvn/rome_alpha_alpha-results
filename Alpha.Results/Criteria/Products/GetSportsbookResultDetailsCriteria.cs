namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data;
    using Fanex.Data.Repository;

    /// <summary>
    /// The criteria GetSportsBookPopupResultCriteria.
    /// </summary>
    public class GetSportsbookResultDetailsCriteria : CriteriaBase
    {
        public int MatchId { get; set; }  

        [SpParam(Ignored = true)]
        public int SportType { get; set; }            

        [SpParam(Ignored = true)]
        public int Handicap2 { get; set; }

        public override string GetSettingKey()
            => "Age_Result_MatchSelResultDetail";

        public override bool IsValid()
            => MatchId > 0;
    }
}