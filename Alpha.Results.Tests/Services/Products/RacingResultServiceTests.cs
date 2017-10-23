namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Racing.DTO;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.DataAccesses;
    using Site.Models.Requests;
    using Site.Services;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class RacingResultServiceTests
    {
        private IRacingResultDataAccess _racingResultDataAccess;
        private IResultEngineAdapter _resultEngineAdapter;
        private RacingResultService _racingResultService;

        [SetUp]
        public void SetUp()
        {
            _racingResultDataAccess = Substitute.For<IRacingResultDataAccess>();
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _racingResultService = new RacingResultService(_racingResultDataAccess, _resultEngineAdapter);
        }

        [Test]
        public void GetResult_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _racingResultService.GetResult(null));
        }

        [Test]
        public void GetResult_RequestIsNotNull_CallGetRacingResults()
        {
            // Arrange
            var request = new NormalResultQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                LeagueId = 1,
                SportId = 151
            };

            // Act
            _racingResultService.GetResult(request);

            // Assert
            _racingResultDataAccess.Received()
                .GetRacingResults(Arg.Is<GetRacingResultCriteria>(
                    c => c.FromDate == request.ResultDate
                        && c.LeagueId == request.LeagueId
                        && c.SportType == request.SportId));
        }

        [Test]
        public void GetResult_RequestIsNotNull_CallHtmlParser()
        {
            // Arrange
            var request = new NormalResultQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                LeagueId = 1,
                SportId = 151
            };

            // Act
            _racingResultService.GetResult(request);

            // Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Any<IList<Racing>>(),
                Arg.Is<ResultSetting>(
                    s => s.SportType == SportType.HorseRacing
                        && s.LanguageCode == request.Language
                        && s.VisibleDetailedLink
                        && s.VisibleFreeHeader
                        && !s.VisibleMatchCodeIDColumn
                        && s.HighlightWinnerTeam));
        }

        [Test]
        public void ExportExcel_RequestIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _racingResultService.ExportExcel(null));
        }

        [Test]
        public void ExportExcel_RequestIsNotNull_CallGetResults()
        {
            // Arrange
            var request = new ExcelNormalResultQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                LeagueId = 1,
                SportId = 151
            };

            // Act
            _racingResultService.ExportExcel(request);

            // Assert
            _racingResultDataAccess.Received()
                .GetRacingResults(Arg.Is<GetRacingResultCriteria>(
                    c => c.FromDate == request.ResultDate
                        && c.LeagueId == request.LeagueId
                        && c.SportType == request.SportId));
        }

        [Test]
        public void ExportExcel_RequestIsNotNull_CallExcelParser()
        {
            // Arrange
            var request = new ExcelNormalResultQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                LeagueId = 1,
                SportId = 151,
                ExcelTitle = "ExelTitle",
                TemplatePath = "Path"
            };

            // Act
            _racingResultService.ExportExcel(request);

            // Assert
            _resultEngineAdapter.Received().ExcelParser(
                Arg.Any<IList<Racing>>(),
                Arg.Is<ResultSetting>(
                    resultSetting => resultSetting.SportType == SportType.HorseRacing
                                    && resultSetting.LanguageCode == request.Language
                                    && resultSetting.ExcelTitle == request.ExcelTitle
                                    && resultSetting.ExcelTemplatePath == request.TemplatePath
                                    && !resultSetting.VisibleMatchCodeIDColumn
                                    && resultSetting.HighlightWinnerTeam));
        }

        [Test]
        public void GetResultDetails_QueryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _racingResultService.GetResultDetails(null));
        }

        [Test]
        public void GetResultDetails_WhenCalled_ExecuteFetch()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                MatchId = 1,
                Race = "0"
            };

            //// Act
            _racingResultService.GetResultDetails(query);

            //// Assert
            _racingResultDataAccess.Received().GetRacingResultDetails(
                Arg.Is<GetRacingResultDetailsCriteria>(
                    criteria => criteria.MatchId == query.MatchId
                            && criteria.RaceNo == 0));
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_UpdateDataWithQueryBetType()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                MatchId = 3,
                Race = "1"
            };

            var racingTickets = new List<Racing>
            {
                new Racing()
            };

            _racingResultDataAccess.GetRacingResultDetails(Arg.Any<GetRacingResultDetailsCriteria>()).Returns(racingTickets);

            //// Act
            _racingResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Is<List<Racing>>(items => items.Count == 1),
                Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_ExecuteHtmlParserWithResultSetting()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery(new Dictionary<int, bool>(), false, LanguageCode.English)
            {
                MatchId = 1,
                Race = "1",
                SportId = 151
            };

            //// Act
            _racingResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(
                Arg.Any<IList<Racing>>(),
                Arg.Is<ResultSetting>(
                resultSetting => resultSetting.SportType == SportType.HorseRacing
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
