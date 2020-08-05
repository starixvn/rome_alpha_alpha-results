using Alpha.Results.Site.Handlers;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Services;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Alpha.Results.Site.Tests.Handlers
{
    [TestFixture]
    public class SabaClubHandlerTests
    {
        private ICacheRefService cacheRefService;
        private SabaClubHandler handler;

        [SetUp]
        public void SetUp()
        {
            cacheRefService = Substitute.For<ICacheRefService>();
            handler = new SabaClubHandler(cacheRefService);
        }

        [Test]
        public void SabaClub_Always_ThrowsTypeInitializationException()
        {
            // Arrange
            var message = new SabaClubResultQuery
            {
                CustId = Arg.Any<string>(),
                GameRoundId = Arg.Any<string>(),
                Language = Arg.Any<string>(),
                SportId = Arg.Any<int>(),
                GameId = Arg.Any<string>(),
                SiteId = Arg.Any<string>(),
            };

            // Assert
            Assert.Throws<TypeInitializationException>(new TestDelegate(() => handler.Handle(message)));
        }

        [Test]
        public void SabaClubNullMessage_Always_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => handler.Handle(null)));
        }
    }
}
