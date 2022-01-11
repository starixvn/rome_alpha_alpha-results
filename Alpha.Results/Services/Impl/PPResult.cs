namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IPPResult : IThirdPartyResult
    {
    }

    public class PPResult : ThirdPartyResult, IPPResult
    {
        public PPResult(string sectionName) : base(sectionName) { }
    }
}