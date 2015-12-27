namespace Alpha.Results.Models
{
    using System;

    public class NormalRequest
    {
        public NormalRequest()
        {
            ResultDate = DateTime.Now;
        }

        public DateTime ResultDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }
    }
}