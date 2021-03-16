namespace Alpha.Results.Site.Models.Requests
{
    using Fanex.Result.ThirdParty.Models.Views;
    using MediatR;

    public class SportsLotteryResultQuery : IRequest<string>
    {
        public string Language { get; set; }
    }
}