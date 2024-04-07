namespace Wallet.Interfaces
{
    public interface IWallet
    {
        bool IsGameRunning { get; set; }

        void Deposit(decimal amount);

        void Withdraw(decimal amount);

        void PlaceBet(decimal amount);
    }
}
