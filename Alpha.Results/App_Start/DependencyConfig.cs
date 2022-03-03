namespace Alpha.Results.Site.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Web.Mvc;
    using Alpha.NetThrottling;
    using Alpha.NetThrottling.Models;
    using Alpha.NetThrottling.Resolvers;
    using Alpha.NetThrottling.Utils;
    using Alpha.Web.Helpers;
    using Alpha.Web.Helpers.Impl;
    using DataAccesses;
    using DataAccesses.Impl;
    using Fanex.Caching;
    using Fanex.Data.Repository;
    using Fanex.RemotingRef;
    using Fanex.Result.Core.AllBetCasino;
    using Fanex.Result.Core.Base.Models;
    using Fanex.Result.Core.Base.Utilities;
    using Fanex.Result.Core.GlobalGaming;
    using Fanex.Result.Core.LinkedGames;
    using Fanex.Result.Core.RemotingRef;
    using Fanex.Result.Core.SportsLottery;
    using Fanex.Result.Core.VGaming;
    using Fanex.Result.Core.VirtualGames;
    using Fanex.Result.ThirdParty.Services;
    using Fanex.Result.ThirdParty.Services.Impl;
    using Handlers;
    using MediatR;
    using RestSharp;
    using Services;
    using Services.Impl;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Sunplus.Agent.Model.Base;
    using Sunplus.Agent.Model.Entities;
    using ILogger = NetThrottling.Utils.ILogger;
    using Logger = NetThrottling.Utils.Logger;

    public static class DependencyConfig
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed")]
        public static void Init()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterMediator(container);

            RegisterCrossCuttingConcerns(container);

            RegisterDataAccesses(container);

            RegisterServices(container);

            RegisterNetThrottling(container);

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
            yield return typeof(OutrightResultHandler).Assembly;
        }

        private static void RegisterCrossCuttingConcerns(Container container)
        {
            container.Register(() => Fanex.Logging.Logger.Log, Lifestyle.Singleton);
        }

        private static void RegisterServices(Container container)
        {
            container.RegisterSingleton<IUserSession, UserSessionExt>();
            container.RegisterSingleton<IRemotingRefService, RemotingRefService>();
            container.RegisterSingleton<ICacheService>(new CacheService());
            container.RegisterSingleton<IRefDataHelper, RefDataHelper>();
            container.RegisterSingleton<ICacheRefService, CacheRefService>();

            container.Register<IResultServiceFactory, ResultServiceFactory>(Lifestyle.Scoped);
            container.Register<IReportDateService, ReportDateService>(Lifestyle.Scoped);
            container.Register<IOutrightResultService, OutrightResultService>(Lifestyle.Scoped);
            container.Register<INormalResultService, NormalResultService>(Lifestyle.Scoped);

            container.Register<IResultEngineAdapter, ResultEngineAdapter>(Lifestyle.Scoped);
            container.Register<IAllbetResultBuilder, AllbetResultBuilder>(Lifestyle.Scoped);
            container.Register<Base3rdResultApi, GlobalGamingResultApi>(Lifestyle.Scoped);
            container.Register<IRestClient>(() => new RestClient());
            container.Register<ProductResultServiceFactory, ProductResultServiceFactoryImpl>();
            container.Register<IVirtualGamesResult, VirtualGamesResult>(Lifestyle.Scoped);
            container.Register<Helpers.BrowserHelper, Helpers.BrowserHelperImpl>(Lifestyle.Singleton);
            container.Register<ILinkedGamesResult, LinkedGamesResult>(Lifestyle.Scoped);
            container.Register<ISportsLotteryResult, SportsLotteryResult>(Lifestyle.Scoped);
            container.Register<ISportsLotteryDetailResult>(() => new SportsLotteryDetailResult("SportsLotteryDetailResultConfigs"), Lifestyle.Scoped);
            container.Register<IHabaneroResult>(() => new HabaneroResult("HabaneroResultConfigs"), Lifestyle.Scoped);
            container.Register<ICGResult>(() => new CGResult("CGResultConfigs"), Lifestyle.Scoped);
            container.Register<IWebClient, JsonWebClient>(Lifestyle.Scoped);
            container.Register<IAdvantPlayResult>(() => new AdvantPlayResult("AdvantPlayResultConfigs"), Lifestyle.Scoped);
            container.Register<ISerializer, JsonSerializer>(Lifestyle.Scoped);
            container.Register<IVGamingResult, VGamingResult>(Lifestyle.Scoped);
            container.Register<IKenoResult>(() => new KenoResult("KenoResultConfigs"), Lifestyle.Scoped);
            container.Register<ILotteryResult>(() => new LotteryResult("LotteryResultConfigs"), Lifestyle.Scoped);
            container.Register<ITableGameResult>(() => new TableGameResult("TableGameResultConfigs"), Lifestyle.Scoped);
            container.Register<IAdvantPlayMiniResult>(() => new AdvantPlayMiniResult("AdvantPlayMiniResultConfigs"), Lifestyle.Scoped);
            container.Register<IBBINResult>(() => new BBINResult("BBINResultConfigs"), Lifestyle.Scoped);
            container.Register<IRNGCasinoResult>(() => new RNGCasinoResult("RNGCasinoResultConfigs"), Lifestyle.Scoped);
            container.Register<IPPLiveCasinoResult>(() => new PPLiveCasinoResult("PPLiveCasinoResultConfigs"), Lifestyle.Scoped);
            container.Register<IHappy5LinkedGamesResult>(() => new Happy5LinkedGamesResult("LinkedGamesResultConfigs"), Lifestyle.Scoped);
            container.Register<IMaxGameResult>(() => new MaxGameResult("MaxGameResultConfigs"), Lifestyle.Scoped);
            container.Register<IBGResult>(() => new BGResult("BGResultConfigs"), Lifestyle.Scoped);
            container.Register<IGDGResult>(() => new GDGResult("GDGResultConfigs"), Lifestyle.Scoped);
            container.Register<IJokerResult>(() => new JokerResult("JokerResultConfigs"), Lifestyle.Scoped);
            container.Register<IPGSoftResult>(() => new PGSoftResult("PGSoftResultConfigs"), Lifestyle.Scoped);
            container.Register<IRNGWarResult>(() => new RNGWarResult("RNGWarResultConfigs"), Lifestyle.Scoped);
            container.Register<IIONCasinoResult>(() => new IONCasinoResult("IONCasinoResultConfigs"), Lifestyle.Scoped);
            container.Register<ISpadeGamingResult>(() => new SpadeGamingResult("SpadegamingResultConfigs"), Lifestyle.Scoped);
            container.Register<ICardClubResult>(() => new CardClubResult("CardClubResultConfigs"), Lifestyle.Scoped);
            container.Register<IPPResult>(() => new PPResult("PPResultConfigs"), Lifestyle.Scoped);
            container.Register<IMacauGamesResult>(() => new MacauGamesResult("VoidbridgeResultConfigs"), Lifestyle.Scoped);
            container.RegisterSingleton<PartialUMService, PartialUMServiceImpl>();
        }

        private static void RegisterDataAccesses(Container container)
        {
            container.Register<IDynamicRepository, DynamicRepository>(Lifestyle.Scoped);
            container.Register<IMetricGamingResultDataAccess, MetricGamingResultDataAccess>(Lifestyle.Scoped);
            container.Register<INumberGameResultDataAccess, NumberGameResultDataAccess>(Lifestyle.Scoped);
            container.Register<IParlayResultDataAccess, ParlayResultDataAccess>(Lifestyle.Scoped);
            container.Register<ISportsbookResultDataAccess, SportsbookResultDataAccess>(Lifestyle.Scoped);
            container.Register<IVirtualRacingResultDataAccess, VirtualRacingResultDataAccess>(Lifestyle.Scoped);
        }

        private static void RegisterNetThrottling(Container container)
        {
            container.Register<INetThrottler, NetThrottler>(Lifestyle.Scoped);
            container.Register<IThrottleSetting, ThrottleSetting>(Lifestyle.Scoped);
            container.Register<IClock, Clock>(Lifestyle.Scoped);
            container.Register<ILogger, Logger>(Lifestyle.Scoped);
            container.Register<ICacheServiceFactory, CacheServiceFactory>(Lifestyle.Scoped);
            container.Register<IResolver, BaseResolver>(Lifestyle.Scoped);
        }
    }
}