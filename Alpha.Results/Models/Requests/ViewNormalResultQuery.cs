namespace Alpha.Results.Site.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Views;

    public class ViewNormalResultQuery : IRequest<NormalResultViewModel>
    {
        public ViewNormalResultQuery()
        {
            ResultDate = DateTime.Now;
        }

        public DateTime ResultDate { get; set; }

        public int SportId { get; set; }

        public int LeagueId { get; set; }

        public int BetTypeId { get; set; }

        public string Language { get; set; }

        public IDictionary<int, bool> SportsStatus { get; set; }

        public bool DisableHorseRacingWin { get; set; }
    }
}