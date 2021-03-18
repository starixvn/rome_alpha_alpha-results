namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;

    [TestFixture]
    public class TableGameResultHandlerTests
    {
        private TableGamesResultHandler resultHandler;
        private BrowserHelper browserHelper;
        private ICacheRefService cacheRefService;

        [SetUp]
        public void SetUp()
        {
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            resultHandler = new TableGamesResultHandler(browserHelper, cacheRefService);
        }
      
        [Test]
        public void HandleTableGamesResultQuery_WhenCalled_ReturnResultUrl()
        {
            var query = new TableGamesResultQuery
            {
                CustId = 1,
                LanguageKey = "EN",
                RootUrl = "RootUrl/"
            };

            var actualViewModel = resultHandler.Handle(query);

            var expectedResultUrl = $"RootUrl/game/keno/kenoresult/resultdetail?date={DateTime.Today.ToString("yyyyMMdd")}&language=EN&productId=40&customerid=1&device=W";
            Assert.AreEqual(expectedResultUrl, actualViewModel.ResultPath);
        }

        [Test]
        public void Handle_WhenCalled_ReturnExtendTokenUrl()
        {
            var query = new TableGamesResultQuery
            {
                CustId = 1,
                LanguageKey = "EN",
                RootUrl = "RootUrl/"
            };

            var actualViewModel = resultHandler.Handle(query);

            var expectedExtendTokenUrl = "RootUrl/game/keno/kenoresult/extendtoken?productId=40&userid=1";
            Assert.AreEqual(expectedExtendTokenUrl, actualViewModel.ExtendTokenPath);
        }
    }
}
