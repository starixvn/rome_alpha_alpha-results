namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IFACHAIResult : IThirdPartyResult
    {
    }

    public class FACHAIResult : ThirdPartyResult, IFACHAIResult
    {
        public FACHAIResult(string sectionName) : base(sectionName) { }
    }
}