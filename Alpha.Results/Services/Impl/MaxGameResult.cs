namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IMaxGameResult : IThirdPartyResult
    {
    }

    public class MaxGameResult : ThirdPartyResult, IMaxGameResult
    {
        public MaxGameResult(string sectionName) : base(sectionName) { }
    }
}