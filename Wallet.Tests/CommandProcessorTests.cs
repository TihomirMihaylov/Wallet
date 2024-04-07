using Moq;
using Wallet.Commands;
using Wallet.Interfaces;

namespace Wallet.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private IMock<IWallet> _mockWallet;
        private ICommandProcessor _commandProcessor;

        [SetUp]
        public void Setup()
        {
            _mockWallet = new Mock<IWallet>();
            _commandProcessor = new CommandProcessor();
        }

        [Test]
        public void ParseInput_ExitCommand_ReturnsExitCommand()
        {
            // Arrange
            string input = "exit";

            // Act
            var result = _commandProcessor.ParseInput(input, _mockWallet.Object);

            // Assert
            Assert.IsNotNull(result, "The result was null");
            Assert.IsTrue(result is ExitCommand, "The result is not of type ExitCommand");
        }

        [Test]
        public void ParseInput_DepositCommand_ReturnsDepositCommand()
        {
            // Arrange
            string input = "deposit 10";

            // Act
            var result = _commandProcessor.ParseInput(input, _mockWallet.Object);

            // Assert
            Assert.IsNotNull(result, "The result was null");
            Assert.IsTrue(result is DepositCommand, "The result is not of type DepositCommand");
        }

        [Test]
        public void ParseInput_WithdrawCommand_ReturnsWithdrawCommand()
        {
            // Arrange
            string input = "withdraw 10";

            // Act
            var result = _commandProcessor.ParseInput(input, _mockWallet.Object);

            // Assert
            Assert.IsNotNull(result, "The result was null");
            Assert.IsTrue(result is WithdrawCommand, "The result is not of type WithdrawCommand");
        }

        [Test]
        public void ParseInput_BetCommand_ReturnsPlaceBetCommand()
        {
            // Arrange
            string input = "bet 10";

            // Act
            var result = _commandProcessor.ParseInput(input, _mockWallet.Object);

            // Assert
            Assert.IsNotNull(result, "The result was null");
            Assert.IsTrue(result is PlaceBetCommand, "The result is not of type PlaceBetCommand");
        }

        [TestCase("")] // empty input
        [TestCase("unknowCommand")] //unknown command
        [TestCase("invalid input format")] //invalid input format
        [TestCase("bet 0")] // 0 amount
        [TestCase("bet -1")] // negative amount
        [TestCase("bet abc")] // parsing text
        [TestCase("bet")] // missing amount
        public void ParseInput_InvalidInput_ReturnsNull(string input)
        {
            // Act
            var result = _commandProcessor.ParseInput(input, _mockWallet.Object);

            // Assert
            Assert.IsNull(result, "The result was not null");
        }
    }
}
