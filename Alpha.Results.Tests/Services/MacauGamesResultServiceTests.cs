namespace Alpha.Results.Site.Tests.Services
{
    using Fanex.Result.Core.Voidbridge;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Models.Requests;
    using Site.Services.Impl;

    [TestFixture]
    public class MacauGamesResultServiceTests
    {
        private VoidbridgeApi _voidbridgeApi;
        private MacauGamesResultService _macauGamesResultService;

        [SetUp]
        public void SetUp()
        {
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
                RefNo = "1"
            };

            // Act
            _macauGamesResultService.GetResult(request);

            // Assert
            _voidbridgeApi.Received().GetBetHistoryUrl(request.CustId.ToString(), request.RefNo, request.Language, request.SiteId.ToString());
        }
    }
}
