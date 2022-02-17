namespace Alpha.Results.Site.Tests.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using Fanex.Result.Core.LinkedGames;
    using Fanex.Result.Core.VirtualGames;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class LinkedGamesResultHandlerTests
    {
        private ILinkedGamesResult result;
        private LinkedGamesResultHandler handler;
        private BrowserHelper browserHelper;
        private ICacheRefService cacheRefService;

        [SetUp]
        public void SetUp()
        {
            result = Substitute.For<ILinkedGamesResult>();
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            handler = new LinkedGamesResultHandler(result, browserHelper, cacheRefService);
        }


        [Test]
        public void LinkedGamesResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new Soccer5ResultQuery());

            // Assert
            result.Received().GetSoccer5Result(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        }

        [Test]
        public void LinkedGamesResultQuery_IsMobile_CallGetResultWithFalse()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new Soccer5ResultQuery());

            // Assert
            result.Received().GetSoccer5Result(Arg.Any<string>(), Arg.Any<string>(), Arg.Is<bool>(i => !i), Arg.Any<string>());
        }

        [Test]
        public void LinkedGamesResultQuery_Always_ReturnCorrectTitleFormat()
        {
            // Arrange
            cacheRefService.GetSportName(1).Returns("Sport1");
            cacheRefService.GetBetTypeName(1).Returns("Bettype1");
            result.GetSoccer5Result(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>()).Returns("URL Result");

            // Act
            var act = handler.Handle(new Soccer5ResultQuery { SportTypeId = 1, BetTypeId = 1 });

            // Assert
            Assert.AreEqual("Sport1 - Bettype1", act.Title);
        }

    }
}
