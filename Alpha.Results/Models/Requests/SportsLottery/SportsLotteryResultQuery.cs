namespace Alpha.Results.Site.Models.Requests
{
    using MediatR;

    public class SportsLotteryResultQuery : IRequest<string>
    {
        public string Language { get; set; }
    }
}