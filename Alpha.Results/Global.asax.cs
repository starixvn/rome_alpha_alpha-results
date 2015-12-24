namespace Alpha.Results
{
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Fanex.Data.Configuration.DbSettingProviderManager.Current.Start();

			CheatApplicationName();
		}

		private void CheatApplicationName()
		{
			string applicationName = "AlphaSite";

			// Change the Application Name in runtime.
			var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
			var theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
			var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);

			appNameInfo.SetValue(theRuntime, applicationName);
		}
	}
}