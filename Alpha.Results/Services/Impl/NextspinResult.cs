namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface INextspinResult : IThirdPartyResult
    {
    }

    public class NextspinResult : ThirdPartyResult, INextspinResult
    {
        public NextspinResult(string sectionName) : base(sectionName) { }
    }
}