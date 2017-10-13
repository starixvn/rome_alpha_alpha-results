using System;
using Alpha.Results.Site.Controllers;
using MediatR;
using NSubstitute;
using NUnit.Framework;

namespace Alpha.Results.Site.Tests.Controllers
{
    [TestFixture]
    public class CockfightingControllerTests
    {
        private IMediator mediator;
        private CockfightingController controller;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();
            controller = new CockfightingController(mediator);
        }

        [Test]
        public void Result_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => controller.Result(null)));
        }
    }
}
