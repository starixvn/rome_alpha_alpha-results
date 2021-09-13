namespace Alpha.Results.Site.Tests.Services.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alpha.Web.Helpers;
    using Constants;
    using Fanex.Data.Repository;
    using Fanex.Result.Core.Base;
    using Fanex.Result.Core.Bitcoin.DTO;
    using Fanex.Result.Core.GoldDeluxe.DTO;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Criteria;
    using Site.Models.Requests;
    using Site.Services;
    using Site.Services.Impl.Products;

    [TestFixture]
    public class BitcoinResultServiceTests
    {
        private IDynamicRepository _dynamicRepository;
        private IResultEngineAdapter _resultEngineAdapter;
        private BitcoinResultService _resultService;
        private PartialUMService _partialUMService;

        [SetUp]
        public void SetUp()
        {
            _dynamicRepository = Substitute.For<IDynamicRepository>();
            _resultEngineAdapter = Substitute.For<IResultEngineAdapter>();
            _partialUMService = Substitute.For<PartialUMService>();
            _resultService = new BitcoinResultService(_dynamicRepository, _resultEngineAdapter, _partialUMService);
        }

        [Test]
        public void GetResultDetails_Always_BiddingGameDetailToBelongingMatch()
        {
            // Arrange
            var request = new NormalResultDetailsQuery(new Dictionary<int, bool>(), LanguageCode.English)
            {
                MatchId = 1
            };
            var bitcoin = new List<Bitcoin> { new Bitcoin { Match3rdId = 1 } };
            var gameDetails = new List<GameDetail> { new GameDetail { Match3rdId = 1 }, new GameDetail { Match3rdId = 2 } };
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultDetailsCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.GetResultDetails(request);

            // Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Is<List<Bitcoin>>(i => i.First().GameResults.First().Match3rdId == 1), Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResultDetails_ResultSetting_IsPopup_IsTrue()
        {
            // Arrange
            var request = new NormalResultDetailsQuery(new Dictionary<int, bool>(), LanguageCode.English)
            {
                MatchId = 1
            };
            var bitcoin = new List<Bitcoin> { new Bitcoin() };
            var gameDetails = new List<GameDetail>();
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultDetailsCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.GetResultDetails(request);

            // Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Any<List<Bitcoin>>(), Arg.Is<ResultSetting>(
                i => i.IsPopUp));
        }

        [Test]
        public void GetResult_Always_BiddingGameDetailToBelongingMatch()
        {
            // Arrange
            var request = new NormalResultQuery(new Dictionary<int, bool>(), LanguageCode.English);
            
            var bitcoin = new List<Bitcoin> { new Bitcoin { Match3rdId = 1 } };
            var gameDetails = new List<GameDetail> { new GameDetail { Match3rdId = 1 }, new GameDetail { Match3rdId = 2 } };
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.GetResult(request);

            // Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Is<List<Bitcoin>>(i => i.First().GameResults.First().Match3rdId == 1), Arg.Any<ResultSetting>());
        }

        [Test]
        public void GetResult_ResultSetting_IsPopup_IsFalse()
        {
            // Arrange
            var request = new NormalResultQuery(new Dictionary<int, bool>(), LanguageCode.English);
            
            var bitcoin = new List<Bitcoin> { new Bitcoin() };
            var gameDetails = new List<GameDetail>();
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.GetResult(request);

            // Assert
            _resultEngineAdapter.Received().HtmlParser(Arg.Any<List<Bitcoin>>(), Arg.Is<ResultSetting>(
                i => !i.IsPopUp));
        }

        [Test]
        public void ExportExcel_ResultSetting_IsPopup_IsFalse()
        {
            // Arrange
            var request = new ExcelNormalResultQuery(new Dictionary<int, bool>(), LanguageCode.English);

            var bitcoin = new List<Bitcoin> { new Bitcoin() };
            var gameDetails = new List<GameDetail>();
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.ExportExcel(request);

            // Assert
            _resultEngineAdapter.Received().ExcelParser(Arg.Any<List<Bitcoin>>(), Arg.Is<ResultSetting>(
                i => !i.IsPopUp));
        }

        [Test]
        public void ExportExcel_Always_BiddingGameDetailToBelongingMatch()
        {
            // Arrange
            var request = new ExcelNormalResultQuery(new Dictionary<int, bool>(), LanguageCode.English);

            var bitcoin = new List<Bitcoin> { new Bitcoin { Match3rdId = 1 } };
            var gameDetails = new List<GameDetail> { new GameDetail { Match3rdId = 1 }, new GameDetail { Match3rdId = 2 } };
            _dynamicRepository.FetchMultiple<Bitcoin, GameDetail>(Arg.Any<GetBitcoinResultCriteria>()).
                Returns(new Tuple<IEnumerable<Bitcoin>, IEnumerable<GameDetail>>(bitcoin, gameDetails));

            // Act
            _resultService.ExportExcel(request);

            // Assert
            _resultEngineAdapter.Received().ExcelParser(Arg.Is<List<Bitcoin>>(i => i.First().GameResults.First().Match3rdId == 1), Arg.Any<ResultSetting>());
        }
    }
}
