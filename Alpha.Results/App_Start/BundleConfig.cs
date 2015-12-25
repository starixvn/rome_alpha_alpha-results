namespace Alpha.Results.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //RegisterStyleSheetBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            RegisterNormalResultJavascript(bundles);
        }

        public const string NormalResultJavascriptBundleUrl = "~/bundles/scripts/normalresult";

        private static void RegisterNormalResultJavascript(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(NormalResultJavascriptBundleUrl).Include(
                        "~/Scripts/Normal/normal-result.js"));
        }
    }
}