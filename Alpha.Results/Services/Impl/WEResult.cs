namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IWEResult : IThirdPartyResult
    {
    }

    public class WEResult : ThirdPartyResult, IWEResult
    {
        public WEResult(string sectionName) : base(sectionName) { }
    }
}