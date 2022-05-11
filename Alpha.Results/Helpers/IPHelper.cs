namespace Alpha.Results.Site.Helpers
{
    using Sunplus.Agent.Model.Common;

    public interface IPHelper
    {
        string GetClientIP();
    }

    public class IPHelperImpl : IPHelper
    {
        public string GetClientIP()
            => AgentIPFormat.GetClientIP();
    }
}