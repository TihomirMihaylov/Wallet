using Wallet.Interfaces;

namespace Wallet.Commands
{
    public class DepositCommand : CashCommand
    {
        public DepositCommand(decimal amount, IWallet wallet)
            : base(amount, wallet)
        { }

        public override void Execute() => Wallet.Deposit(Amount);
    }
}
