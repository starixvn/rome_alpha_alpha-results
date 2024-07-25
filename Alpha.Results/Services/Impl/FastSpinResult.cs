namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IFastSpinResult : IThirdPartyResult
    {
    }

    public class FastSpinResult : ThirdPartyResult, IFastSpinResult
    {
        public FastSpinResult(string sectionName) : base(sectionName) { }
    }
}