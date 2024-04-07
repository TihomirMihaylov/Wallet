using Wallet.Helpers;

namespace Wallet.Tests
{
    [TestFixture]
    public class GameHelperTests
    {
        [Test]
        public void CalculateWinnings_ReturnsCorrectValue()
        {
            // Arrange
            var betAmount = 10m;
            var coefficient = 2.5;
            var expectedWinnings = 25m;

            // Act
            var actualWinnings = GameHelper.CalculateWinnings(betAmount, coefficient);

            // Assert
            Assert.AreEqual(expectedWinnings, actualWinnings);
        }

        [Test]
        public void CalculateWinnings_ReturnsZeroForZeroCoefficient()
        {
            // Arrange
            var betAmount = 10m;
            var coefficient = 0;
            var expectedWinnings = 0m;

            // Act
            var actualWinnings = GameHelper.CalculateWinnings(betAmount, coefficient);

            // Assert
            Assert.AreEqual(expectedWinnings, actualWinnings);
        }

        [Test]
        public void CalculateWinnings_ReturnsZeroForZeroBetAmount()
        {
            // Arrange
            var betAmount = 0m;
            var coefficient = 2.5;
            var expectedWinnings = 0m;

            // Act
            var actualWinnings = GameHelper.CalculateWinnings(betAmount, coefficient);

            // Assert
            Assert.AreEqual(expectedWinnings, actualWinnings);
        }

        [Test]
        public void CalculateWinnings_RoundingUpReturnsCorrectValue()
        {
            // Arrange
            var betAmount = 10.20201m;
            var coefficient = 2.5;
            var expectedWinnings = 25.51m;

            // Act
            var actualWinnings = GameHelper.CalculateWinnings(betAmount, coefficient);

            // Assert
            Assert.AreEqual(expectedWinnings, actualWinnings);
        }

        [Test]
        public void CalculateWinnings_RoundingDownReturnsCorrectValue()
        {
            // Arrange
            var betAmount = 10.20199m;
            var coefficient = 2.5;
            var expectedWinnings = 25.5m;

            // Act
            var actualWinnings = GameHelper.CalculateWinnings(betAmount, coefficient);

            // Assert
            Assert.AreEqual(expectedWinnings, actualWinnings);
        }
    }
}