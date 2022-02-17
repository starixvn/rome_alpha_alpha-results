namespace Alpha.Results.Site.Tests.Services.Products
{
    using Alpha.Results.Site.Services.Impl;
    using NUnit.Framework;

    [TestFixture]
    public class JokerResultTests
    {
        [Test]
        public void Constructor_Always_NotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new JokerResult("JokerResultConfigs"));
        }
    }
}
