namespace Alpha.Results.Commands
{
    public class ViewNormalResultDetailsCommand : ViewNormalResultCommand
    {
        public int MatchId { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public bool IsViewResultFromBetList { get; set; }
    }
}