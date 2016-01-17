namespace Alpha.Results.Site.Tests.Services
{
    using Fanex.Data.Repository;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services;

    [TestFixture]
    public class NormalResultServiceTest
    {
        private IDynamicRepository _repository;
        private IResultServiceFactory _serviceFactory;
        private INormalResultService _service;

        [SetUp]
        public void Init()
        {
            _repository = Substitute.For<IDynamicRepository>();
            _serviceFactory = Substitute.For<IResultServiceFactory>();
        }

        ////[Test]
        ////public void GetLeagues_ResultDateLessThanBalanceUpDate_ThrowArgumentOutOfRangeException()
        ////{
        ////    // Arrange
        ////    var balanceUpDate = DateTime.Today.AddDays(-10);
        ////    var resultDate = balanceUpDate.AddDays(-1);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act & Assert
        ////    Assert.Throws<ArgumentOutOfRangeException>(() =>
        ////        _service.GetLeagues(resultDate, 1, "es-US", false)
        ////    );
        ////}

        ////[Test]
        ////public void GetLeagues_ResultDateGreaterThanServerDate_ThrowArgumentOutOfRangeException()
        ////{
        ////    // Arrange
        ////    var currentDate = DateTime.Today;
        ////    var resultDate = currentDate.AddDays(1);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act & Assert
        ////    Assert.Throws<ArgumentOutOfRangeException>(() =>
        ////        _service.GetLeagues(resultDate, 1, "es-US", false)
        ////    );
        ////}

        //[Test]
        //public void GetLeagues_IsNegativeOrZero_ThrowArgumentOutOfRangeException()
        //{
        //    // Arrange
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Assert
        //    Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetLeagues(Arg.Any<DateTime>(), -1, Arg.Any<string>(), Arg.Any<bool>()));
        //}

        //[Test]
        //public void GetLeagues_LanguageIsEmptyString_ThrowArgumentException()
        //{
        //    // Arrange
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Assert
        //    Assert.Throws<ArgumentException>(() => _service.GetLeagues(Arg.Any<DateTime>(), 1, string.Empty, Arg.Any<bool>()));
        //}

        //[Test]
        //public void GetLeagues_LanguageIsInvalid_ReturnResultWithDefaultLanguage()
        //{
        //    // Arrange
        //    var language = "12-34"; // Hindi - India
        //    var fakeLeagues = new List<League>
        //    {
        //        new League { Id = 1, Name = "Soccer" },
        //        new League { Id = 2, Name = "Basketball" },
        //        new League { Id = 3, Name = "Ice Hockey" }
        //    }.AsEnumerable();

        //    _repository.Fetch<League>(new GetResultLeaguesByDateCriteria { Language = language }).ReturnsForAnyArgs(fakeLeagues);
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act
        //    var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), 1, language, disableHorseRacingWin: false);

        //    // Assert
        //    Assert.AreEqual(fakeLeagues, actualResult);
        //}

        //[Test]
        //public void GetLeagues_LanguageIsUnsupport_ReturnResultWithDefaultLanguage()
        //{
        //    // Arrange
        //    var language = "hi-IN"; // Hindi - India
        //    var fakeLeagues = new List<League>
        //    {
        //        new League { Id = 1, Name = "Soccer" },
        //        new League { Id = 2, Name = "Basketball" },
        //        new League { Id = 3, Name = "Ice Hockey" }
        //    }.AsEnumerable();

        //    _repository.Fetch<League>(new GetResultLeaguesByDateCriteria { Language = language }).ReturnsForAnyArgs(fakeLeagues);
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act
        //    var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), 1, language, disableHorseRacingWin: false);

        //    // Assert
        //    Assert.AreEqual(fakeLeagues, actualResult);
        //}

        //[Test]
        //public void GetLeagues_SportIsHorseRacingAndSettingHRWinIsDisabled_ReturnEmptyEnumerableLeague()
        //{
        //    // Arrange
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act
        //    var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), (int)SportType.HorseRacing, "a language", disableHorseRacingWin: true);

        //    // Assert
        //    Assert.AreEqual(Enumerable.Empty<League>(), actualResult);
        //}

        //[Test]
        //public void GetLeagues_AllPreConditionsAreValid_ReturnDataGetFromRepository()
        //{
        //    // Arrange
        //    var expected = new List<League>();
        //    expected.Add(new League { Id = 1, Name = "League 1" });
        //    expected.Add(new League { Id = 2, Name = "League 2" });
        //    _repository.Fetch<League>(new GetResultLeaguesByDateCriteria()).ReturnsForAnyArgs(expected);
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act
        //    var actualResult = _service.GetLeagues(Arg.Any<DateTime>(), 2, "a language", disableHorseRacingWin: false);

        //    // Assert
        //    Assert.AreEqual(actualResult.ToList(), expected);
        //}

        //[Test]
        //public void GetSports_ResultDateLessThanBalanceUpDate_ThrowArgumentOutOfRangeException()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        //[Test]
        //public void GetSports_ResultDateGreaterThanServerDate_ThrowArgumentOutOfRangeException()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        //////[Test]
        //////public void GetSports_SportsStatusIsNullOrEmpty_ReturnAllDataFromRepository()
        //////{
        //////    // Arrange
        //////    IDictionary<int, bool> fakeSportsStatus = null;
        //////    var fakeSports = new List<Sport>
        //////    {
        //////        new Sport { Id = 1, Name = "Soccer" },
        //////        new Sport { Id = 2, Name = "Basketball" },
        //////        new Sport { Id = 3, Name = "Ice Hockey" }
        //////    }.AsEnumerable();

        //////    _repository.Fetch<Sport>(new GetResultSportsByDateCriteria()).ReturnsForAnyArgs(fakeSports);
        //////    _service = new NormalResultService(_repository, _serviceFactory);

        //////    // Act
        //////    var actualResult = _service.GetSports(Arg.Any<DateTime>(), fakeSportsStatus);

        //////    // Assert
        //////    Assert.AreEqual(fakeSports, actualResult);
        //////}

        //[Test]
        //public void GetSports_SportsStatusIsNotEmpty_ReturnFilterDataFromRepository()
        //{
        //    // Arrange
        //    var fakeSportsStatus = new Dictionary<int, bool>
        //    {
        //        { 3, false }
        //    };

        //    var fakeSports = new List<Sport>
        //    {
        //        new Sport { Id = 1, Name = "Soccer" },
        //        new Sport { Id = 2, Name = "Basketball" },
        //        new Sport { Id = 3, Name = "Ice Hockey" }
        //    }.AsEnumerable();

        //    _repository.Fetch<Sport>(new GetResultSportsByDateCriteria()).ReturnsForAnyArgs(fakeSports);
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act
        //    var actualResult = _service.GetSports(Arg.Any<DateTime>(), fakeSportsStatus);

        //    // Assert
        //    Assert.AreEqual(2, actualResult.Count());
        //}

        //[Test]
        //public void GetResults_RequestIsNull_ThrowArgumentNullException()
        //{
        //    // Arrange
        //    NormalResultQuery request = null;
        //    _service = new NormalResultService(_repository, _serviceFactory);

        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => _service.GetResults(request));
        //}

        ////[Test]
        ////public void GetResults_RequestResultDateLessThanBalanceUpDate_ThrowArgumentOutOfRangeException()
        ////{
        ////    // Arrange
        ////    var balanceUpDate = DateTime.Today.AddDays(-10);
        ////    var resultDate = balanceUpDate.AddDays(-1);
        ////    var language = "en-US";

        ////    _service = new NormalResultService(_repository, _serviceFactory);
        ////    var request = new NormalResultQuery(language) { ResultDate = resultDate };

        ////    // Act & Assert
        ////    Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetResults(request));
        ////}

        ////[Test]
        ////public void GetResults_Soccer()
        ////{
        ////    // Arrange
        ////    var sportId = (int)SportType.Soccer;
        ////    var request = new NormalResultQuery("en-US") { SportId = sportId };

        ////    var fakeSportsbooks = new List<Sportsbook>
        ////    {
        ////        new Sportsbook { },
        ////        new Sportsbook { },
        ////    };

        ////    ISportsbookResultDataAccess dataAccess = Substitute.For<ISportsbookResultDataAccess>();
        ////    var fakeSportbooksResult = new SportsbookResultService(dataAccess);

        ////    _serviceFactory.CreateProductResultService(sportId, Arg.Any<int>()).Returns(fakeSportbooksResult);

        ////    dataAccess.GetSportbookResults(new GetSportsbookResultCriteria { SportType = sportId }).ReturnsForAnyArgs(fakeSportsbooks);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act
        ////    var actualResult = _service.GetResults(request);

        ////    // Assert
        ////    Assert.IsNotEmpty(actualResult);
        ////}

        ////[Test]
        ////public void GetResults_Racing()
        ////{
        ////    // Arrange
        ////    var sportId = (int)SportType.HorseRacing;
        ////    var request = new NormalResultQuery("en-US") { SportId = sportId };

        ////    var fakeSportsbooks = new List<Racing>
        ////    {
        ////        new Racing { },
        ////        new Racing { },
        ////    };

        ////    IRacingResultDataAccess dataAccess = Substitute.For<IRacingResultDataAccess>();
        ////    var fakeRacingResult = new RacingResultService(dataAccess);

        ////    _serviceFactory.CreateProductResultService(sportId, Arg.Any<int>()).Returns(fakeRacingResult);

        ////    dataAccess.GetRacingResults(new GetRacingResultCriteria { SportType = sportId }).ReturnsForAnyArgs(fakeSportsbooks);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act
        ////    var actualResult = _service.GetResults(request);

        ////    // Assert
        ////    Assert.IsNotEmpty(actualResult);
        ////}

        ////[Test]
        ////public void GetResults_NumberGame()
        ////{
        ////    // Arrange
        ////    var sportId = (int)SportType.NumberGame;
        ////    var request = new NormalResultQuery("en-US") { SportId = sportId };

        ////    var fakeNumberGames = new List<NumberGame>
        ////    {
        ////        new NumberGame { },
        ////        new NumberGame { },
        ////    };

        ////    INumberGameResultDataAccess dataAccess = Substitute.For<INumberGameResultDataAccess>();
        ////    var fakeRacingResult = new NumberGameResultService(dataAccess);

        ////    _serviceFactory.CreateProductResultService(sportId, Arg.Any<int>()).Returns(fakeRacingResult);

        ////    dataAccess.GetNumberGameResults(new GetNumberGameResultCriteria { LeagueId = sportId }).ReturnsForAnyArgs(fakeNumberGames);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act
        ////    var actualResult = _service.GetResults(request);

        ////    // Assert
        ////    Assert.IsNotEmpty(actualResult);
        ////}

        ////[Test]
        ////public void GetResults_LiveCasino()
        ////{
        ////    // Arrange
        ////    var sportId = (int)SportType.LiveCasino;
        ////    var request = new NormalResultQuery("en-US") { SportId = sportId };

        ////    var fakeLiveCasinos = new List<LiveCasino>
        ////    {
        ////        new LiveCasino { },
        ////        new LiveCasino { },
        ////    };

        ////    var fakeRacingResult = new LiveCasinoResultService(_repository);

        ////    _serviceFactory.CreateProductResultService(sportId, Arg.Any<int>()).Returns(fakeRacingResult);

        ////    _repository.Fetch<LiveCasino>(new GetLiveCasinoResultCriteria { League = sportId.ToString() }).ReturnsForAnyArgs(fakeLiveCasinos);

        ////    _service = new NormalResultService(_repository, _serviceFactory);

        ////    // Act
        ////    var actualResult = _service.GetResults(request);

        ////    // Assert
        ////    Assert.IsNotEmpty(actualResult);
        ////}
    }
}