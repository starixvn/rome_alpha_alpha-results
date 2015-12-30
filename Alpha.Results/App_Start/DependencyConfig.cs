namespace Alpha.Results.Site.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Mvc;
    using DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Fanex.Game.Keno.Business;
    using Handlers;
    using MediatR;
    using Services;
    using Services.Impl;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    public static class DependencyConfig
    {
        public static void Init()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterMediator(container);

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

        private static void RegisterMediator(Container container)
        {
            var assemblies = GetAssemblies();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
            container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
            container.RegisterSingleton(Console.Out);
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(NormalResultHandler).Assembly;
        }

        private static void RegisterCrossCuttingConcerns(Container container)
        {
            container.Register(() => CacheService.CreateInstance(CacheType.MemoryCache), Lifestyle.Singleton);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IResultServiceFactory, ResultServiceFactory>(Lifestyle.Scoped);
            container.Register<IReportService, ReportService>(Lifestyle.Scoped);
            container.Register<IOutrightResultService, OutrightResultService>(Lifestyle.Scoped);
            container.Register<INormalResultService, NormalResultService>(Lifestyle.Scoped);

            // For Keno Areas.
            container.Register<IKenoGameService, KenoGameService>(Lifestyle.Scoped);
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