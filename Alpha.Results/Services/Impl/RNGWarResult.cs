namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IRNGWarResult : IThirdPartyResult
    {
    }

    public class RNGWarResult : ThirdPartyResult, IRNGWarResult
    {
        public RNGWarResult(string sectionName) : base(sectionName) { }
    }
}