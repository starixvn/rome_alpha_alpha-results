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
            var resultService = _resultServiceFactory.CreateProductResultService(0, betTypeId);

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

#pragma warning disable CS0618 // Type or member is obsolete
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
#pragma warning restore CS0618 // Type or member is obsolete
        public void CreateProductResultService_SportIsBelongingToSportsbook_ReturnSportsbookResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, 0);

            //// Assert
            Assert.IsTrue(resultService is SportsbookResultService);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        [TestCase(SportType.HorseRacing)]
        [TestCase(SportType.Greyhound)]
        [TestCase(SportType.Harness)]
#pragma warning restore CS0618 // Type or member is obsolete
        public void CreateProductResultService_SportIsBelongToRacing_ReturnRacingResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, 0);

            //// Assert
            Assert.IsTrue(resultService is RacingResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsNumbergame_ReturnNumbergameResultService()
        {
            //// Act
#pragma warning disable CS0618 // Type or member is obsolete
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.NumberGame, Arg.Any<int>());
#pragma warning restore CS0618 // Type or member is obsolete

            //// Assert
            Assert.IsTrue(resultService is NumberGameResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsLucky3_ReturnLucky3ResultService()
        {
            //// Act
#pragma warning disable CS0618 // Type or member is obsolete
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.Lucky3, Arg.Any<int>());
#pragma warning restore CS0618 // Type or member is obsolete

            //// Assert
            Assert.IsTrue(resultService is Lucky3ResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsLiveCasino_ReturnLiveCasinoResultService()
        {
            //// Act
#pragma warning disable CS0618 // Type or member is obsolete
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.LiveCasino, Arg.Any<int>());
#pragma warning restore CS0618 // Type or member is obsolete

            //// Assert
            Assert.IsTrue(resultService is LiveCasinoResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsAllBet_ReturnAllBetResultService()
        {
            //// Act
#pragma warning disable CS0618 // Type or member is obsolete
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.AllBet, Arg.Any<int>());
#pragma warning restore CS0618 // Type or member is obsolete

            //// Assert
            Assert.IsTrue(resultService is AllBetCasinoResultService);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        [TestCase(SportType.VirtualHorsesRacing)]
        [TestCase(SportType.VirtualGreyhounds)]
        [TestCase(SportType.VirtualMotors)]
        [TestCase(SportType.VirtualCycling)]
        [TestCase(SportType.VirtualSpeedway)]
#pragma warning restore CS0618 // Type or member is obsolete
        public void CreateProductResultService_SportIsBelongToVirtualRacing_ReturnVirtualRacingResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, 0);

            //// Assert
            Assert.IsTrue(resultService is VirtualRacingResultService);
        }

        [Test]
        public void CreateProductResultService_SportIsGoldDeluxe_ReturnGoldDeluxeResultService()
        {
            //// Act
#pragma warning disable CS0618 // Type or member is obsolete
            var resultService = _resultServiceFactory.CreateProductResultService((int)SportType.GoldDeluxe, Arg.Any<int>());
#pragma warning restore CS0618 // Type or member is obsolete

            //// Assert
            Assert.IsTrue(resultService is GoldDeluxeResultService);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        [TestCase(SportType.Athletics)]
        [TestCase(SportType.Equestrian)]
#pragma warning restore CS0618 // Type or member is obsolete
        public void CreateProductResultService_OtherSports_ReturnSportsbookResultService(
            int sportId)
        {
            //// Act
            var resultService = _resultServiceFactory.CreateProductResultService(sportId, 0);

            //// Assert
            Assert.IsTrue(resultService is SportsbookResultService);
        }
    }
}
