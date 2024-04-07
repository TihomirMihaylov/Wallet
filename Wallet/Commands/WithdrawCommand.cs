using Wallet.Interfaces;

namespace Wallet.Commands
{
    public class WithdrawCommand : CashCommand
    {
        public WithdrawCommand(decimal amount, IWallet wallet)
            : base(amount, wallet)
        { }

        public override void Execute() => Wallet.Withdraw(Amount);
    }
}
