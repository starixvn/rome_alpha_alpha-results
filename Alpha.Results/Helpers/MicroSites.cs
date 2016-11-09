namespace Alpha.Results.Site.Helpers
{
    using Alpha.Results.Site.Configurations;

    public static class MicroSites
    {
        public static string NG2ResultPath
        {
           get{ return AppPathHelper.GetAppPath(AppSettings.NG2SiteAppPath, "~/Result"); }
        }
    }
}