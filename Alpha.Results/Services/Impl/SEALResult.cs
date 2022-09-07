namespace Alpha.Results.Site.Services.Impl
{
    using Fanex.Result.Core.ThirdParty;

    public interface ISEALResult : IThirdPartyResult
    {
    }

    public class SEALResult : ThirdPartyResult, ISEALResult
    {
        public SEALResult(string sectionName) : base(sectionName) { }
    }

    
}