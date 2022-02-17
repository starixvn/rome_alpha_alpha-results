namespace Alpha.Results.Site.Tests.Models.Views
{
    using Alpha.Results.Site.Models.Requests;
    using NSubstitute;
    using NUnit.Framework;
    using Sunplus.Agent.Model.Entities;

    [TestFixture]
    public class MaxGameResultQueryTests
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
            var model = new MaxGameResultQuery(userSession);

            // Act

            // Assert
            Assert.AreEqual("EN", model.Language);
        }
    }
}