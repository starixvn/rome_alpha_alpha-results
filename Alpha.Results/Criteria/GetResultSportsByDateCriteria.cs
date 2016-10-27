namespace Alpha.Results.Site.Criteria
{
    using System;
    using Fanex.Data.Repository;
    using Sunplus.Agent.Model.BL.Definitions;

    public class GetResultSportsByDateCriteria : CriteriaBase
    {
        public GetResultSportsByDateCriteria(DateTime moveBetsDay)
        {
            MoveBetsDay = moveBetsDay;
        }

        public string EventDate { get; set; }

        public DateTime MoveBetsDay { get; }

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