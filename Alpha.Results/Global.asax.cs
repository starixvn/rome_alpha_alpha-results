namespace Alpha.Results.Site
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using Auth.Web;
    using Sunplus.Agent.Utilities;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyConfig.Init();

            Fanex.Data.Configuration.DbSettingProviderManager.Current.Start();

            ShareSession.Init();
        }

        /// <summary>
        /// Application error event handler.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            if (ex is HttpException)
            {
                return;
            }

            if (!Request.IsLocal)
            {
                Logs.FilterInfoWarnOrError(ex);
            }
        }
    }
}