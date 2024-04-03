namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IVGamingResult : IThirdPartyResult
    {
    }

    public class VGamingResult : ThirdPartyResult, IVGamingResult
    {
        public VGamingResult(string sectionName) : base(sectionName) { }
    }
}