namespace Alpha.Results.Site.Tests.Services
{
    using NSubstitute;
    using NUnit.Framework;
    using Site.Services.Impl;
    using Site.Services.Impl.Products;
    using Sunplus.Agent.Model.BL.Definitions;

    [TestFixture]
    public class ResultServiceFactoryTests
    {
        private ResultServiceFactory _resultServiceFactory;

        [SetUp]
        public void SetUp()
        {
            _resultServiceFactory = new ResultServiceFactory();
        }

        [TestCase(9)]
        [TestCase(29)]
        public void CreateProductResultService_BetTypeIsMixParlayOrSystemParlay_ReturnParlayResultService(int betTypeId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(Arg.Any<int>(), betTypeId);

            //// Assert
            Assert.IsTrue(resultService is ParlayResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsSoccerAndBetTypeIsInRangeOfMetricGaming_ReturnMetricGamingResultService(
            [Range(801, 899, 1)] int betTypeId)
        {
            //// Act
            var sportId = 1;
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, betTypeId);

            //// Assert
            Assert.IsTrue(resultService is MetricGamingResultService);
        }

        [TestCase(SportType.Soccer)]
        [TestCase(SportType.BasketBall)]
        [TestCase(SportType.Netball)]
        [TestCase(SportType.FootBall)]
        [TestCase(SportType.Rugby)]
        [TestCase(SportType.IceHockey)]
        [TestCase(SportType.FieldHockey)]
        [TestCase(SportType.Tennis)]
        [TestCase(SportType.VolleyBall)]
        [TestCase(SportType.Badminton)]
        [TestCase(SportType.Squash)]
        [TestCase(SportType.BaseBall)]
        [TestCase(SportType.Golf)]
        [TestCase(SportType.Motorsports)]
        [TestCase(SportType.HRFixedOdds)]
        [TestCase(SportType.Billard)]
        [TestCase(SportType.Cycling)]
        [TestCase(SportType.Fencing)]
        [TestCase(SportType.Judo)]
        [TestCase(SportType.ModernPentathlon)]
        [TestCase(SportType.Rowing)]
        [TestCase(SportType.Sailing)]
        [TestCase(SportType.Shooting)]
        [TestCase(SportType.Taekwondo)]
        [TestCase(SportType.Triathlon)]
        [TestCase(SportType.Wrestling)]
        [TestCase(SportType.Winter)]
        [TestCase(SportType.ESports)]
        [TestCase(SportType.VirtualSports)]
        [TestCase(SportType.VirtualTennis)]
        public void CreateProductResultService_SportIsBelongingToSportsbook_ReturnSportsbookResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is SportsbookResultService);
        }

        [TestCase(SportType.HorseRacing)]
        [TestCase(SportType.Greyhound)]
        [TestCase(SportType.Harness)]
        public void CreateProductResultService_SportIsBelongToRacing_ReturnRacingResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is RacingResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsNumbergame_ReturnNumbergameResultService()
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.NumberGame, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is NumberGameResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsLiveCasino_ReturnLiveCasinoResultService()
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.LiveCasino, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is LiveCasinoResultService);
        }

        [TestCase(SportType.VirtualHorsesRacing)]
        [TestCase(SportType.VirtualGreyhounds)]
        [TestCase(SportType.VirtualMotors)]
        [TestCase(SportType.VirtualCycling)]
        [TestCase(SportType.VirtualSpeedway)]
        public void CreateProductResultService_SportIsBelongToVirtualRacing_ReturnVirtualRacingResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is VirtualRacingResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsGoldDeluxe_ReturnGoldDeluxeResultService()
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.GoldDeluxe, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is GoldDeluxeResultService);
        }

        [TestCase(SportType.Athletics)]
        [TestCase(SportType.Equestrian)]
        public void CreateProductResultService_OtherSports_ReturnSportsbookResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, Arg.Any<int>());

            //// Assert
            Assert.IsTrue(resultService is SportsbookResultService);
        }
    }
}