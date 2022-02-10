using Fanex.Result.Core.ThirdParty;

namespace Alpha.Results.Site.Services.Impl
{
    public interface ICGResult : IThirdPartyResult
    {
    }

    public class CGResult : ThirdPartyResult, ICGResult
    {
        public CGResult(string sectionName) : base(sectionName) { }
    }    
}