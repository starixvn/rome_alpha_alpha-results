namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using MediatR;
    using Sunplus.Agent.Model.Entities;
    using Views;

    public class OutrightResultQuery : IRequest<OutrightResultViewModel>
    {
        public OutrightResultQuery()
        {
            DateTime currentDate = DateTime.Today;
            FromDate = currentDate;
            ToDate = currentDate;
        }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SportType { get; set; }

        public int LeagueId { get; set; }

        public string Language
        {
            get
            {
                return UserSession.Current.Language;
            }
        }
    }
}