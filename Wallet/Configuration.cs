namespace Wallet
{
    public static class Configuration //in a real app this will be the appsettings.json
    {
        //chances
        public const double LossProbability = 0.5;
        public const double SmallWinProbability = 0.4;
        public const double BigWinProbability = 0.1;

        //coefficient ranges
        public const double SmallWinLowerBoundaryCoefficient = 1;
        public const double SmallWinUpperBoundaryCoefficient = 2;
        public const double BigWinLowerBoundaryCoefficient = 2;
        public const double BigWinUpperBoundaryCoefficient = 10;
    }
}
