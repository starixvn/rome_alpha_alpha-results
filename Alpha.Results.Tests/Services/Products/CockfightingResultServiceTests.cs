namespace Alpha.Results.Site.Tests.Services.Products
{
    using Fanex.Logging;
    using Fanex.Result.Core.CockFighting;
    using Fanex.Result.Core.CockFighting.Exceptions;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services.Impl;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CockfightingResultServiceTests
    {
        private CockfightingResultService _cockfightingResultService;
        private ICockFightingAPI _cockfightingApi;
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _cockfightingApi = Substitute.For<ICockFightingAPI>();
            _logger = Substitute.For<ILogger>();
            _cockfightingResultService = new CockfightingResultService(_cockfightingApi, _logger);
        }

        [Test]
        public void GetResultUrl_IsKeepAliveIsTrue_ExecuteExtendToken()
        {
            //// Arrange
            var query = new CockfightingResultQuery
            {
                CustomerId = 10,
                IsKeepAlive = true
            };

            //// Act
            _cockfightingResultService.GetResultUrl(query);

            //// Assert
            _cockfightingApi.Received().ExtendToken(Arg.Is<string>(custId => custId == query.CustomerId.ToString()));
        }

        [TestCase("E", "en")]
        [TestCase("J", "jp")]
        [TestCase("CT", "ch")]
        [TestCase("CS", "cs")]
        [TestCase("TH", "th")]
        [TestCase("KO", "ko")]
        [TestCase("VI", "vi")]
        [TestCase("E1", "en")]
        public void GetResultUrl_WhenCalled_ExecuteGetResultToken(string languageKey, string exptectedLanguageCode)
        {
            //// Arrange
            var query = new CockfightingResultQuery
            {
                CustomerId = 10,
                LanguageKey = languageKey
            };

            //// Act
            _cockfightingResultService.GetResultUrl(query);

            //// Assert
            _cockfightingApi.Received().GetResultToken(
                Arg.Is<string>(custId => custId == query.CustomerId.ToString()),
                Arg.Is<string>(language => language == exptectedLanguageCode));
        }

        [Test]
        public void GetResultUrl_ApiServiceIsNotAvailable_ReturnEmptyResultUrl()
        {
            //// Arrange
            var query = new CockfightingResultQuery
            {
                CustomerId = 10
            };
            _cockfightingApi.GetResultToken(Arg.Any<string>()).Returns(x => { throw new CockFightingException(); });

            //// Act
            var actualResultUrl = _cockfightingResultService.GetResultUrl(query);

            //// Assert
            Assert.IsEmpty(actualResultUrl);
        }

        [Test]
        public void GetResultUrl_ApiServiceIsNotAvailable_ExecuteLogError()
        {
            //// Arrange
            var query = new CockfightingResultQuery
            {
                CustomerId = 10
            };

            _cockfightingApi.GetResultToken(Arg.Any<string>()).Returns(x => { throw new CockFightingException("Error Message"); });

            //// Act
            _cockfightingResultService.GetResultUrl(query);

            //// Assert
            _logger.Received().Error(Arg.Is<string>(message => !string.IsNullOrEmpty(message)), Arg.Any<Exception>());
        }
    }
}
