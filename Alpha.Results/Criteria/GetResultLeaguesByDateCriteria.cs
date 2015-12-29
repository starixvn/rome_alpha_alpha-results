namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;
    using Sunplus.Agent.Model.BL.Definitions;

    public class GetResultLeaguesByDateCriteria : CriteriaBase
    {
        public string EventDate { get; set; }

        public int SportType { get; set; }

        public bool IsShowAll
        {
            get
            {
                return AppSettings.LocalTest;
            }
        }

        public string Language { get; set; }

        public override string GetSettingKey()
        {
            return "Age_Result_LeagueSelByDate";
        }
    }
}