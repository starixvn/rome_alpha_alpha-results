namespace Alpha.Results.Site.Helpers
{
    public interface IPHelper
    {
        string GetClientIP();
    }

    public class IPHelperImpl : IPHelper
    {
        public string GetClientIP()
            => Web.Helpers.IPHelper.GetClientIP();
    }
}