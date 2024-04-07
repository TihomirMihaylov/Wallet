using Microsoft.Extensions.DependencyInjection;
using Wallet.Interfaces;

namespace Wallet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IWallet, Wallet>()
                .AddSingleton<ICommandProcessor, CommandProcessor>()
                .AddSingleton<IGameManager, GameManager>()
                .BuildServiceProvider();

            var manager = serviceProvider.GetRequiredService<IGameManager>();
            manager.StartGame();
        }
    }
}
