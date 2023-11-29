namespace Alpha.Results.Site.Tests.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using AlphaPlus.User.Models;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class VirtualGamesResultHandlerTests
    {
        private IUserSession userSession;
        private IVirtualGamesResult result;
        private ICacheRefService cacheRefService;
        private VirtualGamesResultHandler handler;
        private BrowserHelper browserHelper;

        [SetUp]
        public void SetUp()
        {
            userSession = Substitute.For<IUserSession>();
            result = Substitute.For<IVirtualGamesResult>();
            cacheRefService = Substitute.For<ICacheRefService>();
            browserHelper = Substitute.For<BrowserHelper>();

            handler = new VirtualGamesResultHandler(result, cacheRefService, browserHelper);
        }


        [Test]
        public void VirtualGamesResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new VirtualGamesResultQuery(userSession));

            // Assert
            result.Received().GetResult(Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<System.DateTime>(), Arg.Any<string>(), Arg.Any<string>());
        }


        [Test]
        public void VirtualGamesResultQuery_IsMobile_CallGetResultWithM()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new VirtualGamesResultQuery(userSession));

            // Assert
            result.Received().GetResult(Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<System.DateTime>(), Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
