namespace Alpha.Results.Models
{
    public class NormalDetailsRequest : NormalRequest
    {
        public int MatchId { get; set; }

        public long BetId { get; set; }

        public string Race { get; set; }

        public long RefNum { get; set; }

        public bool IsViewResultFromBetList { get; set; }
    }
}