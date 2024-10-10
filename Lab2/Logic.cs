namespace Lab2
{
    public class Logic
    {
        public static int CalculateWays(int N)
        {
            if (N % 2 != 0)
            {
                return 0; 
            }

            int[] dp = new int[N + 1];
            dp[0] = 1; 
            dp[2] = 3; 

            for (int i = 4; i <= N; i += 2)
            {
                dp[i] = 4 * dp[i - 2] - dp[i - 4];
            }

            return dp[N];
        }
    }
}
