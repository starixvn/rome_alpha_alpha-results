namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IJokerResult : IThirdPartyResult
    {
    }

    public class JokerResult : ThirdPartyResult, IJokerResult
    {
        public JokerResult(string sectionName) : base(sectionName) { }
    }
}