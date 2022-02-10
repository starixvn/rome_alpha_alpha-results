namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IHappy5LinkedGamesResult : IThirdPartyResult
    {
    }

    public class Happy5LinkedGamesResult : ThirdPartyResult, IHappy5LinkedGamesResult
    {
        public Happy5LinkedGamesResult(string sectionName) : base(sectionName) { }
    }
}