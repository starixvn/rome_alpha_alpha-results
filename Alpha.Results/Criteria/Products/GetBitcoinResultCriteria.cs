namespace Alpha.Results.Site.Criteria
{
    using System;
    using Fanex.Data.Repository;

    public class GetBitcoinResultCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public int LeagueId { get; set; }

        public DateTime MoveBetsDay { get; set; }

        public override string GetSettingKey()
            => "Age_Result_Match3rdSelByLeague";

        public override bool IsValid()
            => FromDate > DateTime.MinValue && LeagueId >= 0 && MoveBetsDay > DateTime.MinValue;
    }
}