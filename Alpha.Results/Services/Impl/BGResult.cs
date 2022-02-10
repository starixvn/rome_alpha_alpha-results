namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IBGResult : IThirdPartyResult
    {
    }

    public class BGResult : ThirdPartyResult, IBGResult
    {
        public BGResult(string sectionName) : base(sectionName) { }
    }

    
}