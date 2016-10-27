namespace Alpha.Results.Site
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using ONEbook.UM.Filters;
    using Sunplus.Agent.Utilities;
    using Web;

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

            GlobalFilters.Filters.Add(new CheckUMFilter());

            Logs.WriteInfo("Alpha - Results - Application Start");
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
                if (ex.Message.Contains("Extend Token Error UserID"))
                {
                    return;
                }

                Logs.FilterInfoWarnOrError(ex);
            }
        }

        protected void Application_End()
        {
            HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember(
                "_theRuntime",
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField,
                null,
                null,
                null);

            if (runtime == null)
            {
                return;
            }

            string shutDownMessage = (string)runtime.GetType().InvokeMember(
                "_shutDownMessage",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
                null,
                runtime,
                null);

            string shutDownStack = (string)runtime.GetType().InvokeMember(
                "_shutDownStack",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
                null,
                runtime,
                null);

            Logs.WriteInfo($"\r\n\r\n_shutDownMessage={shutDownMessage}\r\n\r\n_shutDownStack={shutDownStack}");
        }
    }
}