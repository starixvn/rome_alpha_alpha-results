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
    public class TableGameResultHandlerTests
    {
        private TableGamesResultHandler resultHandler;
        private BrowserHelper browserHelper;
        private ICacheRefService cacheRefService;
        private ITableGameResult tableGameResult;
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            browserHelper = Substitute.For<BrowserHelper>();
            cacheRefService = Substitute.For<ICacheRefService>();
            tableGameResult = Substitute.For<ITableGameResult>();
            resultHandler = new TableGamesResultHandler(browserHelper, cacheRefService, tableGameResult);

            userSession = Substitute.For<IUserSession>();
            userSession.LangKey.Returns("EN");
            userSession.CustId.Returns(1);
            userSession.RoleId.Returns((byte)2);
        }
      
        [Test]
        public void HandleTableGamesResultQuery_WhenCalled_ReturnResultUrl()
        {
            var query = new TableGamesResultQuery(userSession);
            tableGameResult.GetResult(Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<DateTime>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns("Table game result url");
            var actualViewModel = resultHandler.Handle(query);

            Assert.AreEqual("Table game result url", actualViewModel.ResultUrl);
        }        
    }
}
