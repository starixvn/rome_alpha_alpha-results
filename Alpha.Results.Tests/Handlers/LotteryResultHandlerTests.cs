namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using AlphaPlus.User.Models;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class LotteryResultHandlerTests
    {
        private ICacheRefService cacheRefService;
        private LotteryResultHandler _lotteryResultHandler;
        private BrowserHelper browserHelper;
        private ILotteryResult lotteryResult;
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            lotteryResult = Substitute.For<ILotteryResult>();
            _lotteryResultHandler = new LotteryResultHandler(cacheRefService, lotteryResult, browserHelper);

            userSession = Substitute.For<IUserSession>();
            userSession.LangKey.Returns("EN");
            userSession.CustId.Returns(1);
        }

        [Test]
        public void HandleLotteryResultQuery_WhenCalled_ReturnResultUrl()
        {
            var query = new LotteryResultQuery(userSession);
            lotteryResult.GetResult(Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<DateTime>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns("Lottery result url");
            var actualViewModel = _lotteryResultHandler.Handle(query);

            Assert.AreEqual("Lottery result url", actualViewModel.ResultUrl);
        }
    }
}
