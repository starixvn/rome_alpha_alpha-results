namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IVirtualGamesDetailResult : IThirdPartyResult
    {
    }

    public class VirtualGamesDetailResult : ThirdPartyResult, IVirtualGamesDetailResult
    {
        public VirtualGamesDetailResult(string sectionName) : base(sectionName) { }
    }
}