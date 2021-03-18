namespace Alpha.Results.Site.Tests.Handlers
{
    using Alpha.Results.Site.Helpers;
    using Fanex.Result.Core.SportsLottery;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class SportsLotteryResultHandlerTests
    {
        private ISportsLotteryResult result;
        private SportsLotteryResultHandler handler;
        private BrowserHelper browserHelper;

        [SetUp]
        public void SetUp()
        {
            result = Substitute.For<ISportsLotteryResult>();
            browserHelper = Substitute.For<BrowserHelper>();

            handler = new SportsLotteryResultHandler(result, browserHelper);
        }


        [Test]
        public void VirtualGamesResultQuery_Always_CallGetResult()
        {
            // Arrange


            // Act
            handler.Handle(new SportsLotteryResultQuery());

            // Assert
            result.Received().GetResultPage(Arg.Any<bool>(), Arg.Any<string>());
        }


        [Test]
        public void SportsLotteryResultQuery_IsMobile_CallGetResultWithM()
        {
            // Arrange
            browserHelper.IsMobile().Returns(true);

            // Act
            handler.Handle(new SportsLotteryResultQuery());

            // Assert
            result.Received().GetResultPage(Arg.Is<bool>(i => i == false), Arg.Any<string>());
        }
    }
}
