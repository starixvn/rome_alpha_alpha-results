namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IIONCasinoResult : IThirdPartyResult
    {
    }

    public class IONCasinoResult : ThirdPartyResult, IIONCasinoResult
    {
        public IONCasinoResult(string sectionName) : base(sectionName) { }
    }
}