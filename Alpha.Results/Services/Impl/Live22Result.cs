namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ILive22Result : IThirdPartyResult
    {
    }

    public class Live22Result : ThirdPartyResult, ILive22Result
    {
        public Live22Result(string sectionName) : base(sectionName) { }
    }
}