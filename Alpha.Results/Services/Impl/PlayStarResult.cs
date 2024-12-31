namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IPlayStarResult : IThirdPartyResult
    {
    }

    public class PlayStarResult : ThirdPartyResult, IPlayStarResult
    {
        public PlayStarResult(string sectionName) : base(sectionName) { }
    }
}