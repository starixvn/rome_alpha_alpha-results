namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IONLiveCasinoResult : IThirdPartyResult
    {
    }

    public class ONLiveCasinoResult : ThirdPartyResult, IONLiveCasinoResult
    {
        public ONLiveCasinoResult(string sectionName) : base(sectionName) { }
    }
}