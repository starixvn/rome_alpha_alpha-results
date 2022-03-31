namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IFGGResult : IThirdPartyResult
    {
    }

    public class FGGResult : ThirdPartyResult, IFGGResult
    {
        public FGGResult(string sectionName) : base(sectionName) { }
    }
}