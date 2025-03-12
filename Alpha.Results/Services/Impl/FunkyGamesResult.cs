namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IFunkyGamesResult : IThirdPartyResult
    {
    }

    public class FunkyGamesResult : ThirdPartyResult, IFunkyGamesResult
    {
        public FunkyGamesResult(string sectionName) : base(sectionName) { }
    }
}