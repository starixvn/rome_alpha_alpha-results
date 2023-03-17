namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IJiliResult : IThirdPartyResult
    {
    }

    public class JiliResult : ThirdPartyResult, IJiliResult
    {
        public JiliResult(string sectionName) : base(sectionName) { }
    }
}