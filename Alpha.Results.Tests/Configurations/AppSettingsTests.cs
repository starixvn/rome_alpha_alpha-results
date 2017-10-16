namespace Alpha.Results.Site.Tests.Configurations
{
    using System.Collections.Specialized;
    using NUnit.Framework;
    using Site.Configurations;

    [TestFixture]
    public class AppSettingsTests
    {
        [Test]
        public void NG2SiteAppPath_HasConfig_ReturnsCorrectSetting()
        {
            // Arrange
            AppSettings.AppSettingValues = new NameValueCollection
            {
                ["NG2SiteVirtualPath"] = "Path"
            };
            var expectedSetting = "Path";

            // Act
            var actualSetting = AppSettings.NG2SiteAppPath;

            // Assert
            Assert.AreEqual(expectedSetting, actualSetting);
        }

        [Test]
        public void NG2SiteAppPath_NotHasConfig_ReturnsNull()
        {
            // Arrange
            AppSettings.AppSettingValues = new NameValueCollection
            {
            };

            // Act
            var actualSetting = AppSettings.NG2SiteAppPath;

            // Assert
            Assert.Null(actualSetting);
        }
    }
}
