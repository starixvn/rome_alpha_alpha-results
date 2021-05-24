namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using Alpha.Results.Site.Helpers;
    using Alpha.Results.Site.Services;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class KenoResultHandlerTests
    {
        private KenoResultHandler _kenoResultHandler;
        private BrowserHelper browserHelper;
        private ICacheRefService cacheRefService;
        private IKenoResult kenoResult;
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            kenoResult = Substitute.For<IKenoResult>();
            cacheRefService = Substitute.For<ICacheRefService>();
            browserHelper = Substitute.For<BrowserHelper>();
            userSession = Substitute.For<IUserSession>();
            userSession.LangKey.Returns("EN");
            userSession.CustId.Returns(1);

            _kenoResultHandler = new KenoResultHandler(cacheRefService, kenoResult, browserHelper);
        }

        [Test]
        public void HandleKenoResultQuery_WhenCalled_ReturnResultUrl()
        {
            var query = new KenoResultQuery(userSession);
            kenoResult.GetResult(Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<DateTime>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns("Keno Result url");

            var actualViewModel = _kenoResultHandler.Handle(query);

            Assert.AreEqual("Keno Result url", actualViewModel.ResultUrl);
        }        
    }
}
