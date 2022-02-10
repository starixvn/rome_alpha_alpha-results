namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IRNGCasinoResult : IThirdPartyResult
    {
    }

    public class RNGCasinoResult : ThirdPartyResult, IRNGCasinoResult
    {
        public RNGCasinoResult(string sectionName) : base(sectionName) { }
    }
}