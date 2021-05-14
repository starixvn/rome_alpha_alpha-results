using Fanex.Result.Core.Habanero;

namespace Alpha.Results.Site.Services.Impl
{
    public class AdvantPlayResult : HabaneroResult, IAdvantPlayResult
    {
        public AdvantPlayResult(string sectionName) : base(sectionName) { }
    }
}