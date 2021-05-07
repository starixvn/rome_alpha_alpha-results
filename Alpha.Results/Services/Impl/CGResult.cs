using Fanex.Result.Core.Habanero;

namespace Alpha.Results.Site.Services.Impl
{
    public class CGResult : HabaneroResult, ICGResult
    {
        public CGResult(string sectionName) : base(sectionName) { }
    }
}