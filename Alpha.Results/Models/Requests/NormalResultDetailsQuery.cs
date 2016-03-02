namespace Alpha.Results.Site.Models.Requests
{
    using System.Collections.Generic;
    using Alpha.Results.Site.Models.Views;
    using MediatR;

    public class NormalResultDetailsQuery : NormalResultQuery, IRequest<NormalDetailViewModel>
    {
        public NormalResultDetailsQuery() : base()
        {
        }

        internal NormalResultDetailsQuery(
            IDictionary<int, bool> sportStatus,
            bool disableHorseRacingWin,
            string language) : base(sportStatus, disableHorseRacingWin, language)
        {
        }

        public int MatchId { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public bool IsViewResultFromBetList { get; set; }
    }
}