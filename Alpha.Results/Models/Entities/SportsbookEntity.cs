namespace Alpha.Results.Site.Models.Entities
{
    using System;

    public class SportsbookEntity
    {
        public int SportType { get; set; }
        public int Handicap2 { get; set; }
        public string BetCheck { get; set; }
        public int Bettype { get; set; }
        public string RefNo { get; set; }
        public bool IsHTCal { get; set; }
        public bool Calculate { get; set; }
        public string GoalRecord { get; set; }
        public bool IsNeutral { get; set; }
        public string EventStatus { get; set; }
        public int? LiveAwayScore { get; set; }
        public byte SettlementStatus { get; set; }
        public int? LiveHomeScore { get; set; }
        public int? FinalHomeScore { get; set; }
        public int? HtAwayScore { get; set; }
        public int? HtHomeScore { get; set; }
        public int AwayId { get; set; }
        public int HomeId { get; set; }
        public DateTime KickOffTime { get; set; }
        public DateTime EventDate { get; set; }
        public string MatchCode { get; set; }
        public string Lcolor { get; set; }
        public int MatchId { get; set; }
        public int LeagueId { get; set; }
        public string BetStatus { get; set; }
        public int? FinalAwayScore { get; set; }
        public bool NoHTScore { get; set; }
    }
}