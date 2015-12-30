namespace Alpha.Results.Site.Criteria
{
    using Fanex.Data.Repository;
    using Sunplus.Agent.Model.BL.Definitions;

    public class GetResultSportsByDateCriteria : CriteriaBase
    {
        public string EventDate { get; set; }

        public bool IsShowAll
        {
            get
            {
                return AppSettings.LocalTest;
            }
        }

        public override string GetSettingKey()
        {
            return "Age_Result_SportSelByDate";
        }
    }
}