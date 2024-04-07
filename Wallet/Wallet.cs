using Wallet.Enums;
using Wallet.Helpers;
using Wallet.Interfaces;

namespace Wallet
{
    public class Wallet : IWallet
    {
        private decimal _balance;
        private bool _isGameRunning = true;

        public bool IsGameRunning 
        { 
            get => _isGameRunning;
            set => _isGameRunning = value; 
        }

        public void Deposit(decimal amount)
        {
            var roundedAmount = Math.Round(amount, 2);
            _balance += roundedAmount;
            Console.WriteLine($"Your deposit of ${roundedAmount} was successful. {DisplayCurrentBallance()}");
        }

        public void PlaceBet(decimal amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine($"You do not have enough balance to place a bet of ${amount}! {DisplayCurrentBallance()}");
            }
            else if (amount < 1 || amount > 10)
            {
                Console.WriteLine("Bet amount should be between $1 and $10.");
            }
            else
            {
                var roundedAmount = Math.Round(amount, 2);
                var outcome = GameHelper.GetOutcome();
                if (outcome == Outcome.Loss)
                {
                    _balance -= roundedAmount;
                    Console.WriteLine($"No luck this time! {DisplayCurrentBallance()}");
                }
                else
                {
                    var coefficient = GameHelper.GetCoefficient(outcome);
                    var winnings = GameHelper.CalculateWinnings(roundedAmount, coefficient);
                    _balance = _balance - roundedAmount + winnings;
                    Console.WriteLine($"Congrats - you won ${winnings}! {DisplayCurrentBallance()}");
                }
            }
        }

        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                var roundedAmount = Math.Round(amount, 2);
                _balance -= roundedAmount;
                Console.WriteLine($"Your withdrawal of ${roundedAmount} was successful. {DisplayCurrentBallance()}");
            }
            else
            {
                Console.WriteLine($"{DisplayCurrentBallance()}. You cannot withdraw ${amount}");
            }
        }

        private string DisplayCurrentBallance()
        {
            return $"Your current balance is: ${_balance}";
        }
    }
}
