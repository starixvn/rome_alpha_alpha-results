namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ICardClubResult : IThirdPartyResult
    {
    }

    public class CardClubResult : ThirdPartyResult, ICardClubResult
    {
        public CardClubResult(string sectionName) : base(sectionName) { }
    }

    
}