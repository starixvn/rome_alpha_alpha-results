namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Models.Requests;
    using Site.Services;

    [TestFixture]
    public class CockfightingResultHandlerTests
    {
        private ICockfightingResultService _cockfightingResultService;
        private CockfightingResultHandler _cockfightingResultHandler;

        [SetUp]
        public void SetUp()
        {
            _cockfightingResultService = Substitute.For<ICockfightingResultService>();
            _cockfightingResultHandler = new CockfightingResultHandler(_cockfightingResultService);
        }

        [Test]
        public void HandleCockfightingResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(() => _cockfightingResultHandler.Handle(null)));
        }

        [Test]
        public void HandleCockfightingResultQuery_ResultUrlReturnFromServiceIsNotEmpty_ReturnSuccessStatus()
        {
            //// Arrange
            var resultUrl = "resultUrl";
            _cockfightingResultService
                .GetResultUrl(Arg.Any<CockfightingResultQuery>())
                .Returns(resultUrl);
            var query = new CockfightingResultQuery();

            //// Act
            var viewModel = _cockfightingResultHandler.Handle(query);

            //// Assert
            Assert.IsTrue(viewModel.IsSuccess);
        }

        [Test]
        public void HandleCockfightingResultQuery_ResultUrlReturnFromServiceIsEmpty_ReturnFailStatus()
        {
            //// Arrange
            _cockfightingResultService
                .GetResultUrl(Arg.Any<CockfightingResultQuery>())
                .Returns(string.Empty);
            var query = new CockfightingResultQuery();

            //// Act
            var viewModel = _cockfightingResultHandler.Handle(query);

            //// Assert
            Assert.IsFalse(viewModel.IsSuccess);
        }

        [Test]
        public void HandleCockfightingResultQuery_WhenCalled_ReturnResultUrl()
        {
            //// Arrange
            var resultUrl = "resultUrl";
            _cockfightingResultService
                .GetResultUrl(Arg.Any<CockfightingResultQuery>())
                .Returns(resultUrl);
            var query = new CockfightingResultQuery();

            //// Act
            var viewModel = _cockfightingResultHandler.Handle(query);

            //// Assert
            Assert.AreEqual(resultUrl, viewModel.Url);
        }
    }
}
