namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IBBINResult : IThirdPartyResult
    {
    }

    public class BBINResult : ThirdPartyResult, IBBINResult
    {
        public BBINResult(string sectionName) : base(sectionName) { }
    }
}