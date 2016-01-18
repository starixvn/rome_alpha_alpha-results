namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Criteria;
    using DataAccesses;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Sportsbook.DTO;
    using Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;
    using Site.Services.Impl;
    using Site.Services.Impl.Products;
    using Sunplus.Agent.Model.Entities;
    [TestFixture]
    public class ParlayResultServiceTestscs
    {
        private ParlayResultService _parlayResultService;
        private IParlayResultDataAccess _parlayResultDataAccess;
        private IResultEngineAdapter _resultEngineAdapter;

        [SetUp]
        public void SetUp()
        {
            _parlayResultDataAccess = Substitute.For<IParlayResultDataAccess>();
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _parlayResultService = new ParlayResultService(_parlayResultDataAccess, _resultEngineAdapter);

            UserSessionFactory.CurrentSession = Substitute.For<IUserSession>();
            UserSessionFactory.CurrentSession.Language = "en-US";
        }

        [Test]
        public void GetResultDetails_QueryIsNull_ThrowArgumentNullException()
        {
            NormalResultDetailsQuery query = null;
            Assert.Throws<ArgumentNullException>(() => _parlayResultService.GetResultDetails(null));
        }

        [Test]
        public void GetResultDetails_WhenCalled_ExecuteFetch()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery
            {
                RefNum = 2
            };

            //// Act
            _parlayResultService.GetResultDetails(query);

            //// Assert
            _parlayResultDataAccess.Received().GetParlayResults(Arg.Is<GetParlayResultCriteria>
                (criteria => criteria.RefNo == query.RefNum));
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_UpdateDataWithQueryBetType()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery
            {
                SportId = 1,
                RefNum = 10,
                BetId = 3,
                BetTypeId = 2
            };

            var metricGamingTickets = new List<Parlay>
            {
                new Parlay ()
            };

            _parlayResultDataAccess.GetParlayResults(Arg.Any<GetParlayResultCriteria>()).Returns(metricGamingTickets);

            //// Act
            _parlayResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Is<List<Parlay>>
                (items => items.Count == 1), Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_GotDataFromRepository_ExecuteHtmlParserWithResultSetting()
        {
            //// Arrange
            var query = new NormalResultDetailsQuery
            {
                SportId = 1,
                RefNum = 10,
                BetId = 3,
                BetTypeId = 2
            };

            //// Act
            _parlayResultService.GetResultDetails(query);

            //// Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Any<IList<Parlay>>(), Arg.Is<ResultSetting>(
                resultSetting => !resultSetting.IsOutright
                                && resultSetting.IsParlayPopUp
                                && resultSetting.IsPopUp
                                && resultSetting.LanguageCode == query.Language
                                && !resultSetting.VisibleMatchCodeIDColumn
                                && resultSetting.VisiblePopUpTitle
                                && resultSetting.HighlightWinnerTeam
                ));
        }

        [Test]
        public void GetResult_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _parlayResultService.GetResult(null));
        }

        [Test]
        public void ExportExcel_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _parlayResultService.ExportExcel(null));
        }
    }
}
