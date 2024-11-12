namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IGPIRNGResult : IThirdPartyResult
    {
    }
    public class GPIRNGResult : ThirdPartyResult, IGPIRNGResult
    {
        public GPIRNGResult(string sectionName) : base(sectionName) { }
    }
}