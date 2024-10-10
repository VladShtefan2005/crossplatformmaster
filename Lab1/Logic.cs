namespace Lab1
{
    public static class Logic
    {
        public static (long petyaCoins, long vasyaCoins) Process(string input)
        {
            if (!Validator.ValidateInput(input, out int N, out int K1, out int K2, out long S))
            {
                return (0, 0);
            }

            double[,] dp = new double[N + 1, N + 1];

            dp[K1, K2] = 1.0;

            for (int i = K1; i < N; i++)
            {
                for (int j = K2; j < N; j++)
                {
                    if (dp[i, j] > 0)
                    {
                        dp[i + 1, j] += dp[i, j] * 0.5;
                        dp[i, j + 1] += dp[i, j] * 0.5;
                    }
                }
            }

            double petyaWinProb = 0.0;
            double vasyaWinProb = 0.0;

            for (int i = N; i <= N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    petyaWinProb += dp[i, j];
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = N; j <= N; j++)
                {
                    vasyaWinProb += dp[i, j];
                }
            }

            long petyaCoins = (long)(petyaWinProb / (petyaWinProb + vasyaWinProb) * (double)S);
            long vasyaCoins = S - petyaCoins;

            return (petyaCoins, vasyaCoins);
        }
    }
}
