namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using MediatR;
    using Views;

    public class ViewOutrightResultQuery : IRequest<OutrightViewModel>
    {
        public ViewOutrightResultQuery()
        {
            DateTime currentDate = DateTime.Today;
            FromDate = currentDate;
            ToDate = currentDate;
        }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SportType { get; set; }

        public int LeagueId { get; set; }

        public string Language { get; set; }
    }
}