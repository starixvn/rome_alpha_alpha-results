namespace Alpha.Results.Site.Tests.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using Fanex.Result.Core.SportsLottery;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class SportsLotteryResultHandlerTests
    {
        private ISportsLotteryResult result;
        private SportsLotteryResultHandler handler;
        private BrowserHelper browserHelper;
        private ICacheRefService cacheRefService;
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            result = Substitute.For<ISportsLotteryResult>();
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            userSession = Substitute.For<IUserSession>();
            handler = new SportsLotteryResultHandler(result, browserHelper, cacheRefService);
        }


        [Test]
        public void VirtualGamesResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new SportsLotteryResultQuery(userSession));

            // Assert
            result.Received().GetResultPage(Arg.Any<bool>(), Arg.Any<string>());
        }


        [Test]
        public void SportsLotteryResultQuery_IsMobile_CallGetResultWithM()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new SportsLotteryResultQuery(userSession));

            // Assert
            result.Received().GetResultPage(Arg.Is<bool>(i => i == false), Arg.Any<string>());
        }
    }
}
