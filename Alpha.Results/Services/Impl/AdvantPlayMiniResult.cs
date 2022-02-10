using Fanex.Result.Core.ThirdParty;

namespace Alpha.Results.Site.Services.Impl
{
    public interface IAdvantPlayMiniResult : IThirdPartyResult
    {
    }

    public class AdvantPlayMiniResult : ThirdPartyResult, IAdvantPlayMiniResult
    {
        public AdvantPlayMiniResult(string sectionName) : base(sectionName) { }
    }
}