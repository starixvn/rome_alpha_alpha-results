namespace Alpha.Results.Criteria
{
    using System;
    using Fanex.Data.Repository;

    public class GetResultSportsByDateCriteria : CriteriaBase
    {
        public string EventDate { get; set; }

        public override string GetSettingKey()
        {
            return "Age_Result_SportSelByDate";
        }
    }
}