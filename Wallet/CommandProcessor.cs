using Wallet.Commands;
using Wallet.Interfaces;

namespace Wallet
{
    public class CommandProcessor : ICommandProcessor
    {
        private const string ExitCommandText = "exit";

        private Dictionary<string, Func<decimal, IWallet, ICommand>> _commandsDictionary;

        public CommandProcessor()
        {
            _commandsDictionary = new Dictionary<string, Func<decimal, IWallet, ICommand>>();
            _commandsDictionary["deposit"] = (amount, wallet) => new DepositCommand(amount, wallet);
            _commandsDictionary["withdraw"] = (amount, wallet) => new WithdrawCommand(amount, wallet);
            _commandsDictionary["bet"] = (amount, wallet) => new PlaceBetCommand(amount, wallet);
            _commandsDictionary[ExitCommandText] = (_, wallet) => new ExitCommand(wallet);
        }

        public ICommand? ParseInput(string input, IWallet wallet)
        {
            var parts = input.Split(' ');
            if (parts.Length == 1 && parts[0].ToLower() == ExitCommandText)
            {
                return _commandsDictionary[ExitCommandText].Invoke(default, wallet);
            }
            else if (parts.Length != 2)
            {
                return null;
            }

            var commandName = parts[0].ToLower();
            if (!_commandsDictionary.ContainsKey(commandName))
            {
                return null;
            }

            if (!decimal.TryParse(parts[1], out var amount) || amount <= 0)
            {
                return null;
            }
         
            return _commandsDictionary[commandName].Invoke(amount, wallet);
        }

        public void ExecuteCommand(ICommand command) => command.Execute();
    }
}
