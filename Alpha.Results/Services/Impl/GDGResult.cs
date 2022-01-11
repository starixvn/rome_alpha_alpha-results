namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IGDGResult : IThirdPartyResult
    {
    }

    public class GDGResult : ThirdPartyResult, IGDGResult
    {
        public GDGResult(string sectionName) : base(sectionName) { }
    }

    
}