namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface IHabaneroResult : IThirdPartyResult
    {
    }

    public class HabaneroResult : ThirdPartyResult, IHabaneroResult
    {
        public HabaneroResult(string sectionName) : base(sectionName) { }
    }

    
}