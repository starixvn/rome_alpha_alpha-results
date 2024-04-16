namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISabaxDResult : IThirdPartyResult
    {
    }

    public class SabaxDResult : ThirdPartyResult, ISabaxDResult
    {
        public SabaxDResult(string sectionName) : base(sectionName) { }
    }
}