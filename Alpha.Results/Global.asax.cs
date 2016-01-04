namespace Alpha.Results.Site
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
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

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;

            // ASP.NET store a Session Id in cookie to specify current Session.
            HttpCookie cookie = context.Response.Cookies["ASP.NET_SessionId"];

            if (context.Session != null &&
                !string.IsNullOrEmpty(context.Session.SessionID))
            {
                // Need to store current Session Id during every request.
                cookie.Value = context.Session.SessionID;
                cookie.Domain = context.Request.Url.Host;

                // All Virtual Applications and Folders share this Cookie too.
                cookie.Path = "/";
            }
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