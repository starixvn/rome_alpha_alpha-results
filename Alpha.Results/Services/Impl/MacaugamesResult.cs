namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IMacauGamesResult : IThirdPartyResult
    {
    }

    public class MacauGamesResult : ThirdPartyResult, IMacauGamesResult
    {
        public MacauGamesResult(string sectionName) : base(sectionName) { }
    }
}