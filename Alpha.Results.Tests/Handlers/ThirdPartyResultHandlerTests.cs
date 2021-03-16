namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.MaxGame;
    using Fanex.Result.Core.SportsLottery;
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
        private BrowserHelper browserHelper;

        [SetUp]
        public void SetUp()
        {
            serviceFactory = Substitute.For<ProductResultServiceFactory>();
            cacheRefService = Substitute.For<ICacheRefService>();
            maxGameResult = Substitute.For<IMaxGameResult>();
            sportsLotteryResult = Substitute.For<ISportsLotteryResult>();
            browserHelper = Substitute.For<BrowserHelper>();
            handler = new ThirdPartyResultHandler(serviceFactory, cacheRefService, maxGameResult, sportsLotteryResult, browserHelper);
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
    }
}
