namespace Alpha.Results.Site.Tests.Controllers
{
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class HandHistoryControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private HandHistoryController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();
            userSession = Substitute.For<IUserSession>();

            controller = new HandHistoryController(mediator, userSession);
        }

        [Test]
        public void RNGCasino_Always_CallsMediatorSendRNGCasinoResultQuery()
        {
            // Arrange
            var query = new RNGCasinoResultQuery();

            // Act
            controller.RNGCasino(query);

            // Assert
            mediator.Received().Send(Arg.Any<RNGCasinoResultQuery>());
        }

        [Test]
        public void MacauGames_Always_CallsMediatorSendMacauGamesResultQuery()
        {
            // Arrange
            var query = new MacauGamesResultQuery();

            // Act
            controller.MacauGames(query);

            // Assert
            mediator.Received().Send(Arg.Any<MacauGamesResultQuery>());
        }

        [Test]
        public void FishingWorld_Always_CallsMediatorSendFishingWorldResultQuery()
        {
            // Arrange
            var query = new FishingWorldResultQuery();

            // Act
            controller.FishingWorld(query);

            // Assert
            mediator.Received().Send(Arg.Any<FishingWorldResultQuery>());
        }
    }
}
