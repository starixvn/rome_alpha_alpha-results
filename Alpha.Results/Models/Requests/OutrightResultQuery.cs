namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;
    using Services.Impl;
    using System;
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
                return UserSessionFactory.CurrentSession.Language;
            }
        }
    }
}