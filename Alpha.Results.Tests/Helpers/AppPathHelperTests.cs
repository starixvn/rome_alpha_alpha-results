namespace Alpha.Results.Site.Tests.Helpers
{
    using System;
    using NUnit.Framework;
    using Site.Helpers;

    [TestFixture]
    public class AppPathHelperTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void GetAppPath_WithEmptyAppName_ThrowsArgumentException(string appName)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => AppPathHelper.GetAppPath(appName, string.Empty));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void GetAppPath_WithEmptyVirtualPath_ThrowsArgumentException(string virtualPath)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => AppPathHelper.GetAppPath(string.Empty, virtualPath));
        }

        [Test]
        public void GetAppPath_WithAppNameAndVirtualPathAndNotHasContext_ReturnsEmpty()
        {
            // Arrange
            var validAppName = "ValidAppName";
            var validVirtualPath = "ValidVirtualPath";

            // Act
            var actualAppPath = AppPathHelper.GetAppPath(validAppName, validVirtualPath);

            // Assert
            Assert.IsEmpty(actualAppPath);
        }
    }
}
