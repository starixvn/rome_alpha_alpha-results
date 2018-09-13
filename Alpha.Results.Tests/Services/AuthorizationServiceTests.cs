namespace Alpha.Results.Site.Tests.Services
{
    using Fanex.Data.Repository;
    using NSubstitute;
    using NUnit.Framework;
    using Site.DataAccesses;
    using Site.Models;
    using Site.Services;
    using Site.Services.Impl;

    [TestFixture]
    public class AuthorizationServiceTests
    {
        private const int ActorIdTest = 8;
        private const byte ActorRoleIdTest = 4;
        private const int CustIdTest = 1176092;
        private const int SubAccountIdTest = 0;

        private IAuthorizationDataAccess _dataAccess;
        private IAuthorizationService _service;

        [SetUp]
        public void SetUp()
        {
            _dataAccess = Substitute.For<IAuthorizationDataAccess>();
            _service = new AuthorizationService(_dataAccess);
        }

        [Test]
        public void IsBelonging_ValidInputParams_ReturnsTrue()
        {
            // Arrange
            var actor = new Actor(ActorIdTest, ActorRoleIdTest);
            var belongingInfo = new BelongingInfo(1, true);

            _dataAccess.IsBelonging(Arg.Any<ICriteria>()).Returns(belongingInfo);

            // Act
            var expected = _service.IsBelonging(actor, CustIdTest, SubAccountIdTest, 0);

            // Assert
            Assert.IsTrue(expected);
        }

        [Test]
        public void IsBelonging_DifferenceDownline_ReturnsFalse()
        {
            // Arrange
            var actor = new Actor(ActorIdTest, ActorRoleIdTest);
            var belongingInfo = new BelongingInfo(2, false);

            _dataAccess.IsBelonging(Arg.Any<ICriteria>()).Returns(belongingInfo);

            // Act
            var expected = _service.IsBelonging(actor, CustIdTest, SubAccountIdTest, 0);

            // Assert
            Assert.IsFalse(expected);
        }

        [Test]
        public void IsBelonging_InvalidRoleId_ReturnsFalse()
        {
            // Arrange
            var actor = new Actor(ActorIdTest, ActorRoleIdTest);
            var belongingInfo = new BelongingInfo(100, true);

            _dataAccess.IsBelonging(Arg.Any<ICriteria>()).Returns(belongingInfo);

            // Act
            var expected = _service.IsBelonging(actor, CustIdTest, SubAccountIdTest, 0);

            // Assert
            Assert.IsFalse(expected);
        }
    }
}
