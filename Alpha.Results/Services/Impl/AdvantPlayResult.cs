using Fanex.Result.Core.ThirdParty;

namespace Alpha.Results.Site.Services.Impl
{
    public interface IAdvantPlayResult : IThirdPartyResult
    {
    }
    public class AdvantPlayResult : ThirdPartyResult, IAdvantPlayResult
    {
        public AdvantPlayResult(string sectionName) : base(sectionName) { }
    }
}