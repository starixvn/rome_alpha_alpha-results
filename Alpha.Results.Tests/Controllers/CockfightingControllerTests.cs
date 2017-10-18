namespace Alpha.Results.Site.Tests.Controllers
{
    using System;
    using System.Web.Mvc;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Models.Requests;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class CockfightingControllerTests
    {
        private IMediator mediator;
        private IUserSession userSession;
        private CockfightingController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();

            userSession = Substitute.For<IUserSession>();
            userSession.CustId.Returns(1);
            userSession.LangKey.Returns("E");

            controller = new CockfightingController(mediator, userSession);
        }

        [Test]
        public void Index_Always_ReturnView()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsTrue(result is ViewResult);
        }

        [Test]
        public void Result_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => controller.Result(null)));
        }

        [Test]
        public void Result_RequestIsNotNull_CallMediatorSendCockfightingResultQuery()
        {
            // Arrange
            var request = new CockfightingResultQuery();

            // Act
            controller.Result(request);

            // Assert
            mediator.Received().Send(Arg.Is<CockfightingResultQuery>(
                query => query.CustomerId == userSession.CustId
                    && query.LanguageKey == userSession.LangKey));
        }
    }
}
