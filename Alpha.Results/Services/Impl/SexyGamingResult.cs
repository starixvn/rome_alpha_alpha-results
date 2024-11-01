namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISexyGamingResult : IThirdPartyResult
    {
    }

    public class SexyGamingResult : ThirdPartyResult, ISexyGamingResult
    {
        public SexyGamingResult(string sectionName) : base(sectionName) { }
    }
}