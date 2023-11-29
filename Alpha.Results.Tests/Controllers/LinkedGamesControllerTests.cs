namespace Alpha.Results.Site.Tests.Controllers
{
    using AlphaPlus.User.Models;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Models.Requests;

    [TestFixture]
    public class LinkedGamesControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private LinkedGamesController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            userSession.Language.Returns("en-Us");

            controller = new LinkedGamesController(mediator);
        }

        [Test]
        public void Index_Always_CallsMediatorSendSoccer5ResultQuery()
        {
            // Arrange
            var query = new Soccer5ResultQuery(userSession);

            // Act
            controller.GetSoccer5Result(query);

            // Assert
            mediator.Received().Send(Arg.Any<Soccer5ResultQuery>());
        }
    }
}
