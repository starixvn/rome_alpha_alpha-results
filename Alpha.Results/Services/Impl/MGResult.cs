using Fanex.Result.Core.ThirdParty;

namespace Alpha.Results.Site.Services.Impl
{
    public interface IMGResult : IThirdPartyResult
    {
    }
    public class MGResult : ThirdPartyResult, IMGResult
    {
        public MGResult(string sectionName) : base(sectionName) { }
    }
}