using Alpha.Results.Site.App_GlobalResources;

namespace Alpha.Results.Site.Models
{
    public class BaseResultTab
    {
        public string ProductName { get; protected set; }

        public string ResultLinkText => string.Format(Resources.ResultLinkText, ProductName);
    }
}