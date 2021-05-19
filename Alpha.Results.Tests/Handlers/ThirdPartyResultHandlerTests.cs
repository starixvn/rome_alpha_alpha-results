namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.Habanero;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.Core.PPLiveCasino;
    using Fanex.Result.Core.SportsLottery;
    using Fanex.Result.Core.VGaming;
    using Fanex.Result.ThirdParty.Services;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;
    using Site.Services;

    [TestFixture]
    public class ThirdPartyResultHandlerTests
    {
        private ProductResultServiceFactory serviceFactory;
        private ThirdPartyResultHandler handler;
        private ICacheRefService cacheRefService;
        private IMaxGameResult maxGameResult;
        private ISportsLotteryResult sportsLotteryResult;
        private IPPLiveCasinoResult ppLiveCasinoResult;
        private BrowserHelper browserHelper;
        private IHabaneroResult habaneroResult;
        private ICGResult cgResult;
        private IVGamingResult vgamingResult;

        [SetUp]
        public void SetUp()
        {
            serviceFactory = Substitute.For<ProductResultServiceFactory>();
            cacheRefService = Substitute.For<ICacheRefService>();
            maxGameResult = Substitute.For<IMaxGameResult>();
            sportsLotteryResult = Substitute.For<ISportsLotteryResult>();
            browserHelper = Substitute.For<BrowserHelper>();
            ppLiveCasinoResult = Substitute.For<IPPLiveCasinoResult>();
            habaneroResult = Substitute.For<IHabaneroResult>();
            cgResult = Substitute.For<ICGResult>();
            vgamingResult = Substitute.For<IVGamingResult>();
            handler = new ThirdPartyResultHandler(serviceFactory, cacheRefService, maxGameResult, sportsLotteryResult, ppLiveCasinoResult, habaneroResult, cgResult, vgamingResult, browserHelper);
        }

        [Test]
        public void HandleThirdPartyResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            ThirdPartyResultQuery request = null;

            Assert.Throws<ArgumentNullException>(() => handler.Handle(request));
        }

        [Test]
        public void HandleThirdPartyResultQuery_QueryIsNotNull_CallsCreateProductResultService()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new ThirdPartyResultQuery
            {
                ProductId = 6
            };

            // Act
            handler.Handle(query);

            // Assert
            serviceFactory.Received().CreateProductResultService(Arg.Is(query.ProductId));
        }

        [Test]
        public void HandleThirdPartyPopupResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            ThirdPartyDetailResultQuery request = null;

            Assert.Throws<ArgumentNullException>(() => handler.Handle(request));
        }

        [Test]
        public void HandleThirdPartyPopupResultQuery_QueryIsNotNull_CallsCreateProductResultService()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new ThirdPartyDetailResultQuery
            {
                ProductId = 30
            };

            // Act
            handler.Handle(query);

            // Assert
            serviceFactory.Received().CreateProductResultService(Arg.Is(query.ProductId));
        }


        [Test]
        public void MaxGameResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new MaxGameResultQuery();
            maxGameResult.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns("max game result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("max game result url", act.Result.Value);
        }

        [Test]
        public void SportsLotteryResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new SportsLotteryDetailResultQuery();
            sportsLotteryResult.GetResultDetail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>())
                .Returns("sports lottery result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("sports lottery result url", act.Result.Value);
        }

        [Test]
        public void PPLiveCasinoResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new PPLiveCasinoResultQuery();
            ppLiveCasinoResult.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<string>())
                .Returns("PP Live Casino result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("PP Live Casino result url", act.Result.Value);
        }

        [Test]
        public void HabaneroResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new HabaneroResultQuery() { CustId = 1, GameCode = "1", GameId = "1", Language = "en-US", SiteId = "1" };
            habaneroResult.GetResult("1", "1", "1", "1")
                .Returns("Habanero result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("Habanero result url", act.Result.Value);
        }

        [Test]
        public void CGResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new CGResultQuery() { CustId = 1, GameCode = "1", GameId = "1", Language = "en-US", SiteId = "1" };
            cgResult.GetResult("1", "1", "1", "1")
                .Returns("CG result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("CG result url", act.Result.Value);
        }

        [Test]
        public void VGamingResultQuery_Always_ReturnCorrectViewModel()
        {
            // Arrange
            cacheRefService.GetProductName(Arg.Any<int>()).Returns("ProductName");
            var query = new VGamingResultQuery()
            {
                SportId = 171,
                CurrencyName = "UUS",
                CustId = 1,
                GameId = "1",
                GameRoundId = "gameround",
                Language = "en-US",
                SiteId = "1"
            };
            vgamingResult.GetResult("1", "gameround", "1", "1", 171, "UUS", "en-US").Returns("VGaming result url");

            // Act
            var act = handler.Handle(query);


            // Assert
            Assert.AreEqual("VGaming result url", act.Result.Value);
        }
    }
}
