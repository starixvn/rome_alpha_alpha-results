namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IGPILCResult : IThirdPartyResult
    {
    }

    public class GPILCResult : ThirdPartyResult, IGPILCResult
    {
        public GPILCResult(string sectionName) : base(sectionName) { }
    }
}