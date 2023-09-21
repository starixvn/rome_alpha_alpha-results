namespace Alpha.Results.Site.Tests.Services.Products
{
    using Alpha.Results.Site.Services.Impl;
    using Fanex.Result.Core.ConfigurationHelper;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class KenoResultTests
    {
        private readonly IConfigurationHelper configurationHelper;

        public KenoResultTests()
        {
            this.configurationHelper = Substitute.For<IConfigurationHelper>();
        }

        [Test]
        public void Constructor_Always_NotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new KenoResult("AdvantPlayResultConfigs", configurationHelper));
        }
    }
}
