namespace Alpha.Results.Site.Tests.Services
{
    using Fanex.RemotingRef;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services.Impl;

    [TestFixture]
    public class CacheRefServiceTests
    {
        private IRemotingRefService remotingRefService;
        private CacheRefService cacheRefService;

        [SetUp]
        public void Setup()
        {
            remotingRefService = Substitute.For<IRemotingRefService>();
            cacheRefService = new CacheRefService(remotingRefService);
        }

        [Test]
        public void GetProduct_Awlays_SetProduct()
        {
            //// Arrange

            //// Act
            var act = cacheRefService.GetProductName(16);

            //// Assert
            remotingRefService.Received().GetResourceDataByRefIdAndResourceId(Arg.Is("Product"), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void GetSportName_Awlays_ReceiveCall()
        {
            //// Arrange

            //// Act
            var act = cacheRefService.GetSportName(1);

            //// Assert
            remotingRefService.Received().GetSportName("1", Arg.Any<string>());
        }

        [Test]
        public void GetBettypeName_Awlays_ReceiveCall()
        {
            //// Arrange

            //// Act
            var act = cacheRefService.GetBetTypeName(1);

            //// Assert
            remotingRefService.Received().GetBetTypeName("1", Arg.Any<string>());
        }

        [Test]
        public void GetLeagueName_Awlays_ReceiveCall()
        {
            //// Arrange

            //// Act
            var act = cacheRefService.GetLeagueName(1);

            //// Assert
            remotingRefService.Received().GetLeagueName("1", Arg.Any<string>());
        }
    }
}
