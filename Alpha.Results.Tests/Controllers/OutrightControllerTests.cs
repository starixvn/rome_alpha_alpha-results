namespace Alpha.Results.Site.Tests.Controllers
{
    using System;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Controllers;
    using Site.Models.Requests;

    [TestFixture]
    public class OutrightControllerTests
    {
        private IMediator mediator;
        private OutrightController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();
            controller = new OutrightController(mediator);
        }

        [Test]
        public void Index_Always_CallsMediatorSendOutrightResultQuery()
        {
            // Act
            controller.Index();

            // Assert
            mediator.Received().Send(Arg.Any<OutrightResultQuery>());
        }

        [Test]
        public void ExcelResults_RequestIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => controller.ExcelResults(null)));
        }
    }
}
