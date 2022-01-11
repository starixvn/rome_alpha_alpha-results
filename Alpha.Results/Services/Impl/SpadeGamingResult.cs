namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISpadeGamingResult : IThirdPartyResult
    {
    }

    public class SpadeGamingResult : ThirdPartyResult, ISpadeGamingResult
    {
        public SpadeGamingResult(string sectionName) : base(sectionName) { }
    }
}