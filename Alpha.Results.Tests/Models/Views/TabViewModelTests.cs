namespace Alpha.Results.Site.Tests.Models.Views
{
    using System;
    using NUnit.Framework;
    using Site.Constants;
    using Site.Models.Views;

    [TestFixture]
    public class TabViewModelTests
    {
        [Test]
        public void SelectedTabName_Always_ReturnCorrectValue()
        {
            // Arrange
            var tabName = "TabName";
            Func<int, string> getProductName = (productId) =>
            {
                switch (productId)
                {
                    case ProductIdConstants.NG2:
                        return "NG2";

                    case ProductIdConstants.Lottery:
                        return "Lottery";
                }

                return string.Empty;
            };
            var viewModel = new TabViewModel(tabName, false, false, false, false, false, false, getProductName);
            var expectedValue = "tabname";

            // Act
            var actualValue = viewModel.SelectedTabName;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
