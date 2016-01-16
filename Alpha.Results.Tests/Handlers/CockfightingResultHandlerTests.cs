namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
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
        public void HandleCockfightingResultQuery_ResultUrlIsNotEmpty_ReturnSuccessStatus()
        {
            var resultUrl = "resultUrl";
            _cockfightingResultService
                .GetResultUrl(Arg.Any<CockfightingResultQuery>())
                .Returns(resultUrl);
            var query = new CockfightingResultQuery();

            var viewModel = _cockfightingResultHandler.Handle(query);

            Assert.IsTrue(viewModel.IsSuccess);
        }

        [Test]
        public void HandleCockfightingResultQuery_ResultUrlIsNotEmpty_ReturnResultUrl()
        {
            var resultUrl = "resultUrl";
            _cockfightingResultService
                .GetResultUrl(Arg.Any<CockfightingResultQuery>())
                .Returns(resultUrl);
            var query = new CockfightingResultQuery();

            var viewModel = _cockfightingResultHandler.Handle(query);

            Assert.AreEqual(resultUrl, viewModel.Url);
        }
    }
}
