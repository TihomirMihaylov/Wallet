using Wallet.Enums;

namespace Wallet.Helpers
{
    public static class GameHelper
    {
        static Random random = new();

        public static Outcome GetOutcome()
        {
            var randomNumber = random.Next(1, 101);
            switch (randomNumber)
            {
                case int n when n <= Configuration.LossProbability * 100:
                    return Outcome.Loss;
                case int n when n <= (Configuration.LossProbability + Configuration.SmallWinProbability) * 100:
                    return Outcome.SmallWin;
                default:
                    return Outcome.BigWin;
            }
        }

        public static double GetCoefficient(Outcome outcome)
        {
            if (outcome == Outcome.Loss)
            {
                return 0;
            }

            var randomDouble = random.NextDouble();
            if (outcome == Outcome.SmallWin)
            {
                return (randomDouble * (Configuration.SmallWinUpperBoundaryCoefficient - Configuration.SmallWinLowerBoundaryCoefficient)) + Configuration.SmallWinLowerBoundaryCoefficient;
            }
            else // Outcome.BigWin
            {
                return (randomDouble * (Configuration.BigWinUpperBoundaryCoefficient - Configuration.BigWinLowerBoundaryCoefficient)) + Configuration.BigWinLowerBoundaryCoefficient;
            }
        }

        public static decimal CalculateWinnings(decimal betAmount, double coefficient)
        {
            return Math.Round(betAmount * (decimal)coefficient, 2);
        }
    }
}
