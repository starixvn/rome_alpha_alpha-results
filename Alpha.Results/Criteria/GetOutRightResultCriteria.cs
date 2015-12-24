namespace Alpha.Results.Criteria
{
    using Fanex.Data.Repository;
    using System;

    /// <summary>
    /// The criteria GetOutRightResultCriteria.
    /// </summary>
    public class GetOutRightResultCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsShowAll { get; set; }

        public override string GetSettingKey()
        {
            return "Age_Result_Outright";
        }

        public override bool IsValid()
        {
            return FromDate > DateTime.MinValue && FromDate <= ToDate && ToDate > DateTime.MinValue;
        }
    }
}