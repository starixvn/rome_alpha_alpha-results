namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IPGSoftResult : IThirdPartyResult
    {
    }

    public class PGSoftResult : ThirdPartyResult, IPGSoftResult
    {
        public PGSoftResult(string sectionName) : base(sectionName) { }
    }
}