namespace Alpha.Results.Site.Tests.Models.Views
{
    using Alpha.Results.Site.Models.Requests;
    using AlphaPlus.User.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SportsLotteryDetailResultQueryTests
    {
        private IUserSession userSession;

        [SetUp]
        public void SetUp()
        {
            this.userSession = Substitute.For<IUserSession>();
            userSession.Language.Returns("EN");
        }

        [Test]
        public void Constructor_Always_CallBaseConstructor()
        {
            // Arrange
            var model = new SportsLotteryDetailResultQuery(userSession);

            // Act

            // Assert
            Assert.AreEqual("EN", model.Language);
        }
    }
}