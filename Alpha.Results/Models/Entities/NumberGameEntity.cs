namespace Alpha.Results.Site.Models.Entities
{
    using System;

    public class NumberGameEntity
    {
        public int LeagueId { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime KickOffTime { get; set; }

        public string EventStatus { get; set; }

        public int Seg { get; set; }

        public int Number { get; set; }
    }
}