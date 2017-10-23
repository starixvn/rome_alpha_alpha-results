namespace Alpha.Results.Site.Tests.Services
{
    using System;
    using Fanex.Result.Core.Voidbridge;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.HandHistory;
    using Site.Models.Requests;
    using Site.Services.Impl;

    [TestFixture]
    public class MacauGamesResultServiceTests
    {
        private CompareLogic _compareLogic;
        private VoidbridgeApi _voidbridgeApi;
        private MacauGamesResultService _macauGamesResultService;

        [SetUp]
        public void SetUp()
        {
            _compareLogic = new CompareLogic();
            _voidbridgeApi = Substitute.For<VoidbridgeApi>();
            _macauGamesResultService = new MacauGamesResultService(_voidbridgeApi);
        }

        [Test]
        public void GetResult_Always_CallGetBetHistoryUrlFromApi()
        {
            // Arrange
            var request = new MacauGamesResultQuery()
            {
                CustId = 1,
                RoleId = 2,
                RefNo = "1",
                Language = "en-US"
            };

            // Act
            _macauGamesResultService.GetResult(request);

            // Assert
            _voidbridgeApi.Received().GetBetHistoryUrl(request.CustId.ToString(), request.RefNo, request.Language, Arg.Any<string>());
        }

        [Test]
        public void GetResult_HaveException_ReturnCorrectViewModel()
        {
            // Arrange
            var request = new MacauGamesResultQuery()
            {
                CustId = 1,
                RoleId = 2,
                RefNo = "1",
                Language = "en-US"
            };
            _voidbridgeApi.GetBetHistoryUrl(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(x => { throw new Exception("Message"); });

            var expectedViewModel = new HandHistoryModel(string.Empty, false, "Message");

            // Act
            var actualViewModel = _macauGamesResultService.GetResult(request);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(expectedViewModel, actualViewModel).AreEqual);
        }
    }
}
