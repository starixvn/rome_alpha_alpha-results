using System;

namespace Alpha.Results.Models
{
    public class NormalDetailsRequest : NormalRequest
    {
        public int MatchId { get; set; }

        public bool ViewDetail { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool IsOutright { get; set; }

        public int CustId { get; set; }

        public bool IsChangeSportType { get; set; }

        public bool IsHistoryReport { get; set; }

        public bool IsExportExcel { get; set; }
    }
}