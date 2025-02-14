namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IASKMESLOTResult : IThirdPartyResult
    {
    }
    public class ASKMESLOTResult : ThirdPartyResult, IASKMESLOTResult
    {
        public ASKMESLOTResult(string sectionName) : base(sectionName) { }
    }
}