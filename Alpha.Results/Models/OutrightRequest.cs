namespace Alpha.Results.Models
{
    using System;

    public class OutrightRequest
    {
        public OutrightRequest()
        {
            DateTime currentDate = DateTime.Today;
            FromDate = currentDate;
            ToDate = currentDate;
        }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }
    }
}