namespace Alpha.Results.Commands
{
    using Alpha.Results.ViewModels;
    using MediatR;

    public class ViewNormalResultDetailsQuery : ViewNormalResultQuery, IRequest<NormalDetailViewModel>
    {
        public int MatchId { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public bool IsViewResultFromBetList { get; set; }
    }
}