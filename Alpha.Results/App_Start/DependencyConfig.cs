namespace Alpha.Results.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Services;
    using Services.Impl;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    public static class DependencyConfig
    {
        public static void Init()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterCrossCuttingConcerns(container);

            RegisterDataAccesses(container);

            RegisterServices(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterCrossCuttingConcerns(Container container)
        {
            container.Register<ICache>(() => CacheService.CreateInstance(CacheType.MemoryCache), Lifestyle.Singleton);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IResultServiceFactory, ResultServiceFactory>(Lifestyle.Scoped);
            container.Register<IReportService, ReportService>(Lifestyle.Scoped);
            container.Register<IOutrightResultService, OutrightResultService>(Lifestyle.Scoped);
            container.Register<INormalResultService, NormalResultService>(Lifestyle.Scoped);
        }

        private static void RegisterDataAccesses(Container container)
        {
            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Scoped);
            container.Register<IMetricGamingResultDataAccess, MetricGamingResultDataAccess>(Lifestyle.Scoped);
            container.Register<INumberGameResultDataAccess, NumberGameResultDataAccess>(Lifestyle.Scoped);
            container.Register<IParlayResultDataAccess, ParlayResultDataAccess>(Lifestyle.Scoped);
            container.Register<IRacingResultDataAccess, RacingResultDataAccess>(Lifestyle.Scoped);
            container.Register<ISportsbookResultDataAccess, SportsbookResultDataAccess>(Lifestyle.Scoped);
            container.Register<IVirtualRacingResultDataAccess, VirtualRacingResultDataAccess>(Lifestyle.Scoped);
        }
    }
}