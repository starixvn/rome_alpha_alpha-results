using Alpha.Results.Site.Handlers;
using Alpha.Results.Site.Services;
using AlphaPlus.Logging;
using Fanex.Logging.Extensions.Database;
using NSubstitute;
using NUnit.Framework;

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
            cacheRefService.GetSportName(1).Returns("SportType1");
            cacheRefService.GetBetTypeName(1).Returns("BetType1");
            handler = new SabaClubHandler(cacheRefService);
            LoggingConfig.Init(getDbExceptionInfo: DatabaseInfoGetters.GetDbExceptionInfo);
        }

        //[Test]
        //public void SabaClubNullMessage_Always_ThrowsArgumentNullException()
        //{
        //    Assert.Throws<ArgumentNullException>(new TestDelegate(() => handler.Handle(null)));
        //}

        //[Test]
        //public void SabaClub_Always_ThrowsTypeInitializationException()
        //{
        //    // Arrange
        //    var message = new SabaClubResultQuery();

        //    // Assert
        //    Assert.Throws<NotImplementedException>(new TestDelegate(() => handler.Handle(message)));
        //}

        //[Test]
        //public void Handle_SabaResultIsOK_ReturnSabaViewModel()
        //{
        //    // Arrange
        //    resultService.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
        //        .Returns("url sabaclub");
        //    var message = new SabaClubResultQuery { SportId = 1, GameId = "1" };

        //    // Act
        //    var act = handler.Handle(message);

        //    // Assert
        //    Assert.AreEqual("SportType1 - BetType1", act.Title);
        //    Assert.AreEqual("url sabaclub", act.Result);
        //    Assert.IsTrue(act.IsSuccess);
        //}

        //[Test]
        //public void Handle_SabaResultIsNotOK_ReturnSabaViewModel()
        //{
        //    // Arrange
        //    resultService.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
        //        .Returns(x => { throw new Exception("error"); });
        //    var message = new SabaClubResultQuery { SportId = 1, GameId = "1" };

        //    // Act
        //    var act = handler.Handle(message);

        //    // Assert
        //    Assert.AreEqual("SportType1 - BetType1", act.Title);
        //    Assert.AreEqual("error", act.Result);
        //    Assert.IsFalse(act.IsSuccess);
        //}
    }
}
