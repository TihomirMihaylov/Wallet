using Wallet.Interfaces;

namespace Wallet.Commands
{
    public abstract class CashCommand : ICommand
    {
        protected readonly decimal Amount;
        protected readonly IWallet Wallet;

        public CashCommand(decimal amount, IWallet wallet)
        {
            Amount = amount;
            Wallet = wallet;
        }

        public abstract void Execute();
    }
}
