namespace Alpha.Results.Site.Tests.Services.Products
{
    using Fanex.Result.Core.Base.Models;
    using Fanex.Result.Core.GlobalGaming.DTO;
    using KellermanSoftware.CompareNetObjects;
    using NSubstitute;
    using NUnit.Framework;
    using Site.Constants;
    using Site.Models.HandHistory;
    using Site.Models.Requests;
    using Site.Services.Impl;

    public class FishingWorldResultServiceTests
    {
        private CompareLogic _compareLogic;
        private Base3rdResultApi _globalGamingResultApi;
        private FishingWorldResultService _fishingWorldResultService;

        [SetUp]
        public void SetUp()
        {
            _compareLogic = new CompareLogic();
            _globalGamingResultApi = Substitute.ForPartsOf<Base3rdResultApi>();
            _fishingWorldResultService = new FishingWorldResultService(_globalGamingResultApi);
        }

        [Test]
        public void GetResult_Always_CallsGetResultUrlFromApi()
        {
            // Arrange
            var query = new FishingWorldResultQuery { CustId = 1, RefNo = "1", RoleId = 2, Language = "en-Us" };

            // Act
            _fishingWorldResultService.GetResult(query);

            // Assert
            _globalGamingResultApi.Received().GetResultUrl(Arg.Is<GlobalGamingDTO>(
                dto => dto.CustId == query.CustId.ToString()
                && dto.GameId == query.RefNo
                && dto.Language == query.Language));
        }

        [TestCase(RoleIdConstants.Agent, "3000")]
        [TestCase(RoleIdConstants.Master, "3100")]
        [TestCase(RoleIdConstants.Super, "3200")]
        public void GetResult_Always_CallsGetResultFromApiWithCorrectSiteId(int roleId, string siteId)
        {
            // Arrange
            var query = new FishingWorldResultQuery { CustId = 1, RefNo = "1", RoleId = roleId, Language = "en-Us" };

            // Act
            _fishingWorldResultService.GetResult(query);

            // Assert
            _globalGamingResultApi.Received().GetResultUrl(Arg.Is<GlobalGamingDTO>(dto => dto.SiteId == siteId));
        }

        [Test]
        public void GetResult_NotHaveException_ReturnCorrectHandHistoryModel()
        {
            // Arrange
            var query = new FishingWorldResultQuery { CustId = 1, RefNo = "1", RoleId = 2, Language = "en-Us" };

            _globalGamingResultApi.GetResultUrl(Arg.Any<GlobalGamingDTO>()).Returns("IFrame");

            var expectedModel = new HandHistoryModel("IFrame", true, string.Empty);

            // Act
            var actualModel = _fishingWorldResultService.GetResult(query);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(expectedModel, actualModel).AreEqual);
        }

        [Test]
        public void GetResult_HaveException_ReturnCorrectHandHistoryModel()
        {
            // Arrange
            var query = new FishingWorldResultQuery { CustId = 1, RefNo = "1", RoleId = 2, Language = "en-Us" };

            _globalGamingResultApi.GetResultUrl(Arg.Any<GlobalGamingDTO>()).Returns(x => { throw new System.Exception("Message"); });

            var expectedModel = new HandHistoryModel(string.Empty, false, "Message");

            // Act
            var actualModel = _fishingWorldResultService.GetResult(query);

            // Assert
            Assert.IsTrue(_compareLogic.Compare(expectedModel, actualModel).AreEqual);
        }
    }
}
