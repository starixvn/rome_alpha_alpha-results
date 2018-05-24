namespace Alpha.Results.Site.Tests.Models.Views
{
    using NUnit.Framework;
    using Site.Models.Views;

    [TestFixture]
    public class TabViewModelTests
    {
        [Test]
        public void SelectedTabName_Always_ReturnCorrectValue()
        {
            // Arrange
            var tabName = "TabName";
            var viewModel = new TabViewModel(tabName, false, false, false, false);
            var expectedValue = "tabname";

            // Act
            var actualValue = viewModel.SelectedTabName;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void IsEnableBullfighting_Always_CorrectValueInConstructor()
        {
            // Arrange
            var isEnableBullfighting = true;
            var viewModel = new TabViewModel("test", false, false, false, isEnableBullfighting);

            // Act
            var actualValue = viewModel.IsEnableBullfighting;

            // Assert
            Assert.AreEqual(isEnableBullfighting, actualValue);
        }
    }
}
