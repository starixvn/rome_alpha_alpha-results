namespace Alpha.Results.Site.App_Start
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public const string NormalResultJavascriptBundleUrl = "~/bundles/scripts/normalresult";
        public const string OutrightResultJavascriptBundleUrl = "~/bundles/scripts/outrightresult";
        public const string ResultCoreStyleBundleUrl = "~/bundle/styles/resultcore";

        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJavascriptBundles(bundles);
            RegisterStyleBundles(bundles);
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            RegisterNormalResultJavascript(bundles);
            RegisterOutrightResultJavascript(bundles);
        }

        private static void RegisterNormalResultJavascript(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(NormalResultJavascriptBundleUrl).Include(
                        "~/Scripts/Normal/normal-result.js"));
        }

        private static void RegisterOutrightResultJavascript(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(OutrightResultJavascriptBundleUrl).Include(
                        "~/Scripts/Outright/outright-result.js"));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(ResultCoreStyleBundleUrl).Include(
                "~/Content/Fanex.Result/fanex.result.css",
                "~/Content/result.css"
                ));
        }
    }
}