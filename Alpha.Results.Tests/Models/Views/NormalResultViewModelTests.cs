namespace Alpha.Results.Site.Tests.Models.Views
{
    using System;
    using NUnit.Framework;
    using Site.Models.Views;

    [TestFixture]
    public class NormalResultViewModelTests
    {
        [Test]
        public void Yesterday_Always_ReturnCorrectValue()
        {
            // Arrange
            var expectedValue = DateTime.Now.AddDays(-1);
            var viewModel = new NormalResultViewModel();

            // Act
            var actualValue = viewModel.Yesterday;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Today_Always_ReturnCorrectValue()
        {
            // Arrange
            var expectedValue = DateTime.Now;
            var viewModel = new NormalResultViewModel();

            // Act
            var actualValue = viewModel.Today;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
