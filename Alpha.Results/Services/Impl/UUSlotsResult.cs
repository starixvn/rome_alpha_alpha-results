namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IUUSlotsResult : IThirdPartyResult
    {
    }

    public class UUSlotsResult : ThirdPartyResult, IUUSlotsResult
    {
        public UUSlotsResult(string sectionName) : base(sectionName) { }
    }
}