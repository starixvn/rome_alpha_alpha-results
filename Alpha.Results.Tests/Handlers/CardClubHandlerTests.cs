using Alpha.Results.Site.Handlers;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Services;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Alpha.Results.Site.Tests.Handlers
{
    [TestFixture]
    public class CardClubHandlerTests
    {
        private ICacheRefService cacheRefService;
        private CardClubHandler handler;

        [SetUp]
        public void SetUp()
        {
            cacheRefService = Substitute.For<ICacheRefService>();
            handler = new CardClubHandler(cacheRefService);
        }

        [Test]
        public void CardClub_Always_ThrowsTypeInitializationException()
        {
            // Arrange
            var message = new CardClubResultQuery
            {
                CustId = Arg.Any<string>(),
                GameTypeId = Arg.Any<string>(),
                Language = Arg.Any<string>(),
                SportTypeId = Arg.Any<int>(),
                TransId3rd = Arg.Any<string>(),
            };

            // Assert
            Assert.Throws<TypeInitializationException>(new TestDelegate(() => handler.Handle(message)));
        }

        [Test]
        public void CardClubNullMessage_Always_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => handler.Handle(null)));
        }
    }
}
