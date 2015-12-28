namespace Alpha.Results.Models
{
    using System;

    public class NormalDetailsRequest : NormalRequest
    {
        public int MatchId { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public int CustId { get; set; }

        public bool IsChangeSportType { get; set; }

        public bool IsHistoryReport { get; set; }
    }
}