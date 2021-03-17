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
    public class SportsLotteryControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private ICacheRefService cacheRefService;
        private SportsLotteryController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            cacheRefService = Substitute.For<ICacheRefService>();
            userSession.Language.Returns("en-Us");

            controller = new SportsLotteryController(mediator, userSession, cacheRefService);
        }

        [Test]
        public void Index_Always_CallsMediatorSendSportsLotteryResultQuery()
        {
            // Arrange

            // Act
            controller.Index();

            // Assert
            mediator.Received().Send(Arg.Is<SportsLotteryResultQuery>(msg => msg.Language == userSession.Language));
        }
    }
}
