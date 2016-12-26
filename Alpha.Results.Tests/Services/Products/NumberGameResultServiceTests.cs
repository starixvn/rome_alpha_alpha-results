namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using Criteria;
    using DataAccesses;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.NumberGame.DTO;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class NumberGameResultServiceTests
    {
        private const string DefaultLanguage = "en-US";
        private NumberGameResultService _numberGamingResultService;
        private INumberGameResultDataAccess _numberGameResultDataAccess;
        private IResultEngineAdapter _resultEngineAdapter;

        [SetUp]
        public void SetUp()
        {
            _numberGameResultDataAccess = Substitute.For<INumberGameResultDataAccess>();
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _numberGamingResultService = new NumberGameResultService(_numberGameResultDataAccess, _resultEngineAdapter);
        }

        [Test]
        public void GetResultDetails_QueryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _numberGamingResultService.GetResultDetails(null));
        }

        [Test]
        public void GetResultDetails_WhenCalled_ExecuteFetch()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1
            };

            //// Act
            _numberGamingResultService.GetResultDetails(query);

            //// Assert
            _numberGameResultDataAccess.Received().GetNumberGameResultDetails(
                Arg.Is<GetNumberGameResultDetailsCriteria>(criteria => criteria.MatchId == query.MatchId));
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_UpdateDataWithQueryBetType()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 3
            };

            var metricGamingTickets = new List<NumberGame>
            {
                new NumberGame()
            };

            _numberGameResultDataAccess.GetNumberGameResultDetails(Arg.Any<GetNumberGameResultDetailsCriteria>()).Returns(metricGamingTickets);

            //// Act
            _numberGamingResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Is<List<NumberGame>>(items => items.Count == 1), 
                Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_ExecuteHtmlParserWithResultSetting()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, DefaultLanguage)
            {
                MatchId = 1
            };

            //// Act
            _numberGamingResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Any<IList<NumberGame>>(), 
                Arg.Is<ResultSetting>(
                resultSetting => resultSetting.SportType == SportType.NumberGame
                                && !resultSetting.IsOutright
                                && !resultSetting.IsParlayPopUp
                                && resultSetting.IsPopUp
                                && !resultSetting.VisiblePopUpTitle
                                && resultSetting.LanguageCode == query.Language
                                && !resultSetting.VisibleMatchCodeIDColumn
                                && resultSetting.VisibleFreeHeader
                                && resultSetting.VisibleDetailedLink
                                && resultSetting.HighlightWinnerTeam));
        }
    }
}