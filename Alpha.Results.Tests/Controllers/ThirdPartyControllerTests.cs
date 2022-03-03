namespace Alpha.Results.Site.Tests.Controllers
{
    using Alpha.Results.Site.Services;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class ThirdPartyControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private ThirdPartyController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            userSession.Language.Returns("en-Us");
            userSession.RoleId.Returns((byte)4);

            controller = new ThirdPartyController(mediator, userSession);
        }

        [Test]
        public void Detail_Always_CallsMediatorSendFishingWorldResultQuery()
        {
            // Arrange
            var query = new FishingWorldResultQuery();

            // Act
            controller.Detail(query);

            // Assert
            mediator.Received().Send(Arg.Any<FishingWorldResultQuery>());
        }

        [Test]
        public void MaxGameResult_Always_CallsMediatorSendMaxGameResultQuery()
        {
            // Arrange
            var query = new MaxGameResultQuery(userSession);

            // Act
            controller.MaxGameResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<MaxGameResultQuery>());
        }

        [Test]
        public void SportsLotteryDetailResult_Always_CallsMediatorSendSportsLotteryDetailResultQuery()
        {
            // Arrange
            var query = new SportsLotteryDetailResultQuery(userSession);

            // Act
            controller.SportsLotteryDetailResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<SportsLotteryDetailResultQuery>());
        }

        [Test]
        public void PPLiveCasinoResult_Always_CallsMediatorSendPPLiveCasinoResultQuery()
        {
            // Arrange
            var query = new PPLiveCasinoResultQuery(userSession);

            // Act
            controller.PPLiveCasinoResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<PPLiveCasinoResultQuery>());
        }

        [Test]
        public void HabaneroResult_Always_CallsMediatorSendHabaneroResult()
        {
            // Arrange
            var query = new HabaneroResultQuery(userSession);

            // Act
            controller.HabaneroResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<HabaneroResultQuery>());
        }

        [Test]
        public void CGResult_Always_CallsMediatorSendCGResultQuery()
        {
            // Arrange
            var query = new CGResultQuery(userSession);

            // Act
            controller.CGResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<CGResultQuery>());
        }
        [Test]
        public void VGamingResult_Always_CallsMediatorSendVGamingResultQuery()
        {
            // Arrange
            var query = new VGamingResultQuery(userSession);

            // Act
            controller.VGamingResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<VGamingResultQuery>());
        }
        [Test]
        public void AdvantPlayResult_Always_CallsMediatorSendAdvantPlayResultQuery()
        {
            // Arrange
            var query = new AdvantPlayResultQuery(userSession);

            // Act
            controller.AdvantPlayResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<AdvantPlayResultQuery>());
        }
        [Test]
        public void AdvantPlayMiniResult_Always_CallsMediatorSendAdvantPlayMiniResultQuery()
        {
            // Arrange
            var query = new AdvantPlayMiniResultQuery(userSession);

            // Act
            controller.AdvantPlayMiniResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<AdvantPlayMiniResultQuery>());
        }
        [Test]
        public void BBINResult_Always_CallsMediatorSendBBINResultQuery()
        {
            // Arrange
            var query = new BBINResultQuery(userSession);

            // Act
            controller.BBINResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<BBINResultQuery>());
        }
        [Test]
        public void RngCasinoResult_Always_CallsMediatorSendRNGCasinoResultQuery()
        {
            // Arrange
            var query = new RNGCasinoResultQuery(userSession);

            // Act
            controller.RngCasinoResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<RNGCasinoResultQuery>());
        }
        [Test]
        public void MacauGamesResult_Always_CallsMediatorSendMacauGamesResultQuery()
        {
            // Arrange
            var query = new MacauGamesResultQuery(userSession);

            // Act
            controller.MacauGamesResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<MacauGamesResultQuery>());
        }
        [Test]
        public void PPResult_Always_CallsMediatorSendPPResultQuery()
        {
            // Arrange
            var query = new PPResultQuery(userSession);

            // Act
            controller.PPResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<PPResultQuery>());
        }
        [Test]
        public void SpadeGamingResult_Always_CallsMediatorSendSpadeGamingResultQuery()
        {
            // Arrange
            var query = new SpadeGamingResultQuery(userSession);

            // Act
            controller.SpadeGamingResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<SpadeGamingResultQuery>());
        }
        [Test]
        public void RNGWarResult_Always_CallsMediatorSendRNGWarResultQuery()
        {
            // Arrange
            var query = new RNGWarResultQuery(userSession);

            // Act
            controller.RNGWarResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<RNGWarResultQuery>());
        }
        [Test]
        public void IONCasinoResult_Always_CallsMediatorSendIONCasinoResultQuery()
        {
            // Arrange
            var query = new IONCasinoResultQuery(userSession);

            // Act
            controller.IONCasinoResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<IONCasinoResultQuery>());
        }
        [Test]
        public void PGSoftResult_Always_CallsMediatorSendPGSoftResultQuery()
        {
            // Arrange
            var query = new PGSoftResultQuery(userSession);

            // Act
            controller.PGSoftResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<PGSoftResultQuery>());
        }
        [Test]
        public void JokerResult_Always_CallsMediatorSendJokerResultQuery()
        {
            // Arrange
            var query = new JokerResultQuery(userSession);

            // Act
            controller.JokerResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<JokerResultQuery>());
        }
        [Test]
        public void GDGResult_Always_CallsMediatorSendGDGResultQuery()
        {
            // Arrange
            var query = new GDGResultQuery(userSession);

            // Act
            controller.GDGResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<GDGResultQuery>());
        }
        [Test]
        public void LinkedGamesResult_Always_CallsMediatorSendLinkedGamesResultQuery()
        {
            // Arrange
            var query = new LinkedGamesResultQuery(userSession);

            // Act
            controller.LinkedGamesResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<LinkedGamesResultQuery>());
        }
        [Test]
        public void BGResult_Always_CallsMediatorSendBGResultQuery()
        {
            // Arrange
            var query = new BGResultQuery(userSession);

            // Act
            controller.BGResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<BGResultQuery>());
        }
        [Test]
        public void CardClubResult_Always_CallsMediatorSendCardClubResultQuery()
        {
            // Arrange
            var query = new CardClubResultQuery(userSession);

            // Act
            controller.CardClubResult(query);

            // Assert
            mediator.Received().Send(Arg.Any<CardClubResultQuery>());
        }
    }
}
