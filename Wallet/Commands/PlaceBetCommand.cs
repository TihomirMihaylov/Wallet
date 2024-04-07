using Wallet.Interfaces;

namespace Wallet.Commands
{
    public class PlaceBetCommand : CashCommand
    {
        public PlaceBetCommand(decimal amount, IWallet wallet)
            :base(amount, wallet)
        { }

        public override void Execute() => Wallet.PlaceBet(Amount);
    }
}
