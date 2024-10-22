namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IPlaytechResult : IThirdPartyResult
    {
    }

    public class PlaytechResult : ThirdPartyResult, IPlaytechResult
    {
        public PlaytechResult(string sectionName) : base(sectionName) { }
    }
}