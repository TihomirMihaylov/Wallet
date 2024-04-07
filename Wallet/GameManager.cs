using Wallet.Interfaces;

namespace Wallet
{
    public class GameManager : IGameManager
    {
        private readonly IWallet _wallet;
        private readonly ICommandProcessor _processor;

        public GameManager(IWallet wallet, ICommandProcessor processor)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public void StartGame()
        {
            while (_wallet.IsGameRunning)
            {
                Console.WriteLine("Please submit action:");

                ICommand? command = null;
                while (command == null)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        AskForNewUserInput();
                        continue;
                    }

                    command = _processor.ParseInput(input, _wallet);
                    if (command == null)
                    {
                        AskForNewUserInput();
                    }
                    else
                    {
                        _processor.ExecuteCommand(command);
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine("Thank you for playing! Hope to see you again soon.");
        }

        private void AskForNewUserInput()
        {
            Console.WriteLine("Invalid command. Please submit a new action!");
        }
    }
}
