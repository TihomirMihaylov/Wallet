namespace Wallet.Interfaces
{
    public interface ICommandProcessor
    {
        ICommand? ParseInput(string input, IWallet wallet);

        void ExecuteCommand(ICommand command);
    }
}
