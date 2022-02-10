namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IPPLiveCasinoResult : IThirdPartyResult
    {
    }

    public class PPLiveCasinoResult : ThirdPartyResult, IPPLiveCasinoResult
    {
        public PPLiveCasinoResult(string sectionName) : base(sectionName) { }
    }
}