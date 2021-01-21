using Alpha.Results.Site.Controllers;
using Alpha.Results.Site.Models.Requests;
using MediatR;
using NSubstitute;
using NUnit.Core;
using NUnit.Framework;
using Sunplus.Agent.Model.Entities;
using System.Web.Mvc;

namespace Alpha.Results.Site.Tests.Controllers
{
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
            controller = new LinkedGamesController(mediator, userSession);
        }

        [Test]
        public void LinkedGamesCtor_Always_Called()
        {
            Assert.IsNotNull(controller);
        }

        [Test]
        public void LinkedGamesIndex_Always_ReturnsView()
        {
            // Arrage
            var query = new LinkedGamesResultQuery();

            // Act
            var actionResult = controller.Index(query);

            // Assert
            Assert.IsTrue(actionResult is ViewResult);
        }
    }
}
