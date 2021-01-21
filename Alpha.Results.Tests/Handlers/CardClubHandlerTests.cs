using Alpha.Logging;
using Alpha.Results.Site.Handlers;
using Alpha.Results.Site.Models.Requests;
using Alpha.Results.Site.Services;
using Fanex.Logging.Extensions.Database;
using Fanex.Result.Core.CardClub;
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
            cacheRefService.GetSportName(1).Returns("SportType1");
            cacheRefService.GetBetTypeName(1).Returns("BetType1");
            handler = new CardClubHandler(cacheRefService);
            LoggingConfig.Init(getDbExceptionInfo: DatabaseInfoGetters.GetDbExceptionInfo);
        }

        [Test]
        public void CardClubNullMessage_Always_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => handler.Handle(null)));
        }

        //[Test]
        //public void CardClub_Always_ThrowsTypeInitializationException()
        //{
        //    // Arrange
        //    var message = new CardClubResultQuery
        //    {
        //        CustId = "123",
        //        GameTypeId = "1",
        //        Language = "En",
        //        SportTypeId = 1,
        //        TransId3rd = "123",
        //    };

        //    // Assert
        //    Assert.Throws<NotImplementedException>(new TestDelegate(() => handler.Handle(message)));
        //}

        //[Test]
        //public void Handle_CardClubResultIsOK_ReturnSabaViewModel()
        //{
        //    // Arrange
        //    resultService.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
        //        .Returns("url cardclub");
        //    var message = new CardClubResultQuery { SportTypeId = 1, GameTypeId = "1" };

        //    // Act
        //    var act = handler.Handle(message);

        //    // Assert
        //    Assert.AreEqual("SportType1 - BetType1", act.Title);
        //    Assert.AreEqual("url cardclub", act.Result);
        //    Assert.IsTrue(act.IsSuccess);
        //}

        //[Test]
        //public void Handle_CardClubResultIsNotOk_ReturnExceptionMessage()
        //{
        //    // Arrange
        //    resultService.GetResult(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
        //        .Returns(x => { throw new Exception("error"); });

        //    var message = new CardClubResultQuery { SportTypeId = 1, GameTypeId = "1" };

        //    // Act
        //    var act = handler.Handle(message);

        //    // Assert
        //    Assert.AreEqual("SportType1 - BetType1", act.Title);
        //    Assert.AreEqual("error", act.Result);
        //    Assert.IsFalse(act.IsSuccess);
        //}
    }
}
