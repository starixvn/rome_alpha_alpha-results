using System;
using Alpha.Results.Site.Handlers;
using Alpha.Results.Site.Helpers;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Services;
using Fanex.Result.Core.LinkedGames;
using NSubstitute;
using NUnit.Framework;

namespace Alpha.Results.Site.Tests.Handlers
{
    [TestFixture]
    public class LinkedGamesHandlerTests
    {
        private ICacheRefService cacheRefService;
        private ILinkedGamesResult result;
        private LinkedGamesResultHandler handler;
        private BrowserHelper browserHelper;

        [SetUp]
        public void SetUp()
        {
            result = Substitute.For<ILinkedGamesResult>();
            cacheRefService = Substitute.For<ICacheRefService>();
            browserHelper = Substitute.For<BrowserHelper>();
            handler = new LinkedGamesResultHandler(result, browserHelper, cacheRefService);
        }

        [Test]
        public void LinkedGames_Always_CallResultAPI()
        {
            // Arrange


            // Act
            handler.Handle(new LinkedGamesResultQuery());

            // Assert
            result.Received().GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        }

        [Test]
        public void Soccer5_Always_CallResultAPI()
        {
            // Arrange


            // Act
            handler.Handle(new Soccer5ResultQuery());

            // Assert
            result.Received().GetSoccer5Result(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<string>());
        }
    }
}
