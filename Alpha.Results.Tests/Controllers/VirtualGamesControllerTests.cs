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
            userSession.RoleId.Returns((byte)4);

            controller = new VirtualGamesController(mediator, userSession, cacheRefService);
        }

        [Test]
        public void Index_Always_CallsMediatorSendVirtualGamesResultQuery()
        {
            // Arrange

            // Act
            controller.Index();

            // Assert
            mediator.Received().Send(Arg.Any<VirtualGamesResultQuery>());
        }
    }
}
