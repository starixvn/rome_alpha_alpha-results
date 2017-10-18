namespace Alpha.Results.Site.Helpers
{
    using Configurations;
    using Web.Helpers;

    public static class MicroSites
    {
        public static string NG2ResultPath
        {
            get { return AppPathHelper.GetAppPath(AppSettings.NG2SiteAppPath, "~/Result"); }
        }
    }
}
