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
    public class VirtualGamesControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private ICacheRefService cacheRefService;
        private VirtualGamesController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            cacheRefService = Substitute.For<ICacheRefService>();
            userSession.Language.Returns("en-Us");

            controller = new VirtualGamesController(mediator, userSession, cacheRefService);
        }

        [Test]
        public void Index_Always_CallsMediatorSendVirtualGamesResultQuery()
        {
            // Arrange

            // Act
            controller.Index();

            // Assert
            mediator.Received().Send(Arg.Is<VirtualGamesResultQuery>(msg => msg.Language == userSession.Language));
        }

        [Test]
        public void Detail_Always_CallsMediatorSendVirtualGamesDetailResultQuery()
        {
            // Arrange
            var query = new VirtualGamesDetailResultQuery();

            // Act
            controller.Detail(query);

            // Assert
            mediator.Received().Send(Arg.Is<VirtualGamesDetailResultQuery>(msg => msg.Language == userSession.Language));
        }
    }
}
