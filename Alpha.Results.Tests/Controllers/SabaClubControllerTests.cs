using System.Web.Mvc;
using Alpha.Results.Site.Controllers;
using Alpha.Results.Site.Models.Requests;
using MediatR;
using NSubstitute;
using NUnit.Core;
using NUnit.Framework;
using Sunplus.Agent.Model.Entities;

namespace Alpha.Results.Site.Tests.Controllers
{
    [TestFixture]
    public class SabaClubControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private SabaClubController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();
            userSession = Substitute.For<IUserSession>();
            controller = new SabaClubController(mediator, userSession);
        }

        [Test]
        public void CardClubCtor_Always_Called()
        {
            Assert.IsNotNull(controller);
        }

        [Test]
        public void CardClubIndex_Always_ReturnsView()
        {
            // Arrage
            userSession.RoleId.Returns((byte)4);
            var query = new SabaClubResultQuery();

            // Act
            var actionResult = controller.Index(query);

            // Assert
            Assert.IsTrue(actionResult is ViewResult);
        }
    }
}
