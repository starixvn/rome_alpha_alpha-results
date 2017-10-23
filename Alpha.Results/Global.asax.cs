namespace Alpha.Results.Site
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using Fanex.Logging.Extensions.Database;
    using Fanex.Logging.Extensions.Web;
    using ONEbook.UM.Filters;
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

            var loggingConfiguration = new LoggingConfiguration()
                .UseGetDbExceptionInfo(DatabaseInfoGetters.GetDbExceptionInfo);

            ExceptionHandler.UseConfig(loggingConfiguration);
        }

        /// <summary>
        /// Application error event handler.
        /// </summary>
        protected void Application_Error()
        {
            if (Request.IsLocal)
            {
                return;
            }

            Exception ex = Server.GetLastError();
            ExceptionHandler.Handle(ex);
        }
    }
}
