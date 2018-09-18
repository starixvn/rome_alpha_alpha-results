namespace Alpha.Results.Site.Tests.Models
{
    using NUnit.Framework;
    using Site.Models;

    [TestFixture]
    public class ActorTests
    {
        [Test]
        public void Constructor_Always_AssignCorrectProperties()
        {
            // Arrange
            var actor = new Actor(8, 4);

            // Act & Assert

            Assert.True(actor.ActorId == 8 && actor.ActorRoleId == 4);
        }
    }
}
