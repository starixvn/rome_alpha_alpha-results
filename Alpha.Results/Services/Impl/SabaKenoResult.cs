namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISabaKenoResult : IThirdPartyResult
    {
    }

    public class SabaKenoResult : ThirdPartyResult, ISabaKenoResult
    {
        public SabaKenoResult(string sectionName) : base(sectionName) { }
    }
}