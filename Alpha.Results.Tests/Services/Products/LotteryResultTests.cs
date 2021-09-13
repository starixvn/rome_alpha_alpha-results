namespace Alpha.Results.Site.Tests.Services.Products
{
    using Alpha.Results.Site.Services.Impl;
    using NUnit.Framework;

    [TestFixture]
    public class LotteryResultTests
    {
        [Test]
        public void Constructor_Always_NotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new LotteryResult("AdvantPlayResultConfigs"));
        }
    }
}
