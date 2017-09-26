namespace Alpha.Results.Site.Tests.Handlers
{
    using System;
    using App_GlobalResources;
    using KellermanSoftware.CompareNetObjects;
    using Models.HandHistory;
    using Models.Requests;
    using Models.Views;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Handlers;
    using Site.Services;

    [TestFixture]
    public class HandHistoryResultHandlerTests
    {
        private CompareLogic _compareLogic;
        private IRNGCasinoResultService _rngCasinoResultService;
        private IMacauGamesResultService _macauGamesResultService;
        private IFishingWorldResultService _fishingWorldResultService;
        private HandHistoryResultHandler _handHistoryResultHandler;

        [SetUp]
        public void SetUp()
        {
            _compareLogic = new CompareLogic();

            _rngCasinoResultService = Substitute.For<IRNGCasinoResultService>();
            _macauGamesResultService = Substitute.For<IMacauGamesResultService>();
            _fishingWorldResultService = Substitute.For<IFishingWorldResultService>();

            _handHistoryResultHandler = new HandHistoryResultHandler(
                _rngCasinoResultService,
                _macauGamesResultService,
                _fishingWorldResultService);
        }

        #region RnGCasinoResultQuery

        [Test]
        public void HandleRnGCasinoResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            RNGCasinoResultQuery query = null;

            Assert.Throws<ArgumentNullException>(() => _handHistoryResultHandler.Handle(query));
        }

        [Test]
        public void HandleRnGCasinoResultQuery_QueryIsNotNull_CallGetResultFromService()
        {
            // Arrange
            var query = new RNGCasinoResultQuery
            {
                RefNo = "1",
                RoleId = 2
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _rngCasinoResultService.GetResult(Arg.Any<RNGCasinoResultQuery>()).Returns(result);

            // Act
            _handHistoryResultHandler.Handle(query);

            // Assert
            _rngCasinoResultService.Received().GetResult(Arg.Is(query));
        }

        [Test]
        public void HandleRnGCasinoResultQuery_QueryIsNotNull_ReturnHanHistoryResultViewModel()
        {
            // Arrange
            var message = new RNGCasinoResultQuery
            {
                RefNo = "1",
                RoleId = 2
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _rngCasinoResultService.GetResult(Arg.Any<RNGCasinoResultQuery>()).Returns(result);

            var expectedViewModel = new HandHistoryResultViewModel(Resources.Product_6, result);

            // Act
            var actualViewModel = _handHistoryResultHandler.Handle(message);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(actualViewModel, expectedViewModel).AreEqual);
        }

        #endregion

        #region MacauGamesResultQuery

        [Test]
        public void HandleMacauGamesResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            MacauGamesResultQuery query = null;

            Assert.Throws<ArgumentNullException>(() => _handHistoryResultHandler.Handle(query));
        }

        [Test]
        public void HandleMacauGamesResultQuery_QueryIsNotNull_CallGetResultFromService()
        {
            // Arrange
            var query = new MacauGamesResultQuery
            {
                CustId = 1,
                RoleId = 2,
                RefNo = string.Empty
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _macauGamesResultService.GetResult(Arg.Any<MacauGamesResultQuery>()).Returns(result);

            // Act
            _handHistoryResultHandler.Handle(query);

            // Assert
            _macauGamesResultService.Received().GetResult(Arg.Is(query));
        }

        [Test]
        public void HandleMacauGamesResultQuery_QueryIsNotNull_ReturnHanHistoryResultViewModel()
        {
            // Arrange
            var message = new MacauGamesResultQuery
            {
                CustId = 1,
                RoleId = 2,
                RefNo = string.Empty
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _macauGamesResultService.GetResult(Arg.Any<MacauGamesResultQuery>()).Returns(result);

            var expectedViewModel = new HandHistoryResultViewModel(Resources.Voidbridge, result);

            // Act
            var actualViewModel = _handHistoryResultHandler.Handle(message);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(actualViewModel, expectedViewModel).AreEqual);
        }

        #endregion

        #region FishingWorldResultQuery

        [Test]
        public void HandleFishingWorldResultQuery_QueryIsNull_ThrowArgumentNullException()
        {
            FishingWorldResultQuery query = null;

            Assert.Throws<ArgumentNullException>(() => _handHistoryResultHandler.Handle(query));
        }

        [Test]
        public void HandleFishingWorldResultQuery_QueryIsNotNull_CallGetResultFromService()
        {
            // Arrange
            var query = new FishingWorldResultQuery
            {
                CustId = 1,
                RoleId = 2,
                RefNo = string.Empty
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _fishingWorldResultService.GetResult(Arg.Any<FishingWorldResultQuery>()).Returns(result);

            // Act
            _handHistoryResultHandler.Handle(query);

            // Assert
            _fishingWorldResultService.Received().GetResult(Arg.Is(query));
        }

        [Test]
        public void HandleFishingWorldResultQuery_QueryIsNotNull_ReturnHanHistoryResultViewModel()
        {
            // Arrange
            var message = new FishingWorldResultQuery
            {
                CustId = 1,
                RoleId = 2,
                RefNo = string.Empty
            };

            var result = new HandHistoryModel(string.Empty, true, string.Empty);
            _fishingWorldResultService.GetResult(Arg.Any<FishingWorldResultQuery>()).Returns(result);

            var expectedViewModel = new HandHistoryResultViewModel(Resources.FishingWorld, result);

            // Act
            var actualViewModel = _handHistoryResultHandler.Handle(message);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(actualViewModel, expectedViewModel).AreEqual);
        }

        #endregion
    }
}
