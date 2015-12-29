namespace Alpha.Results.Commands
{
    using System;
    using Sunplus.Agent.Model.Entities;

    public class ViewOutrightResultCommand
    {
        public ViewOutrightResultCommand()
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