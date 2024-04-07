using Wallet.Interfaces;

namespace Wallet.Commands
{
    public class ExitCommand : ICommand
    {
        private readonly IWallet _wallet;

        public ExitCommand(IWallet wallet)
        {
            _wallet = wallet;
        }

        public void Execute() => _wallet.IsGameRunning = false;
    }
}
