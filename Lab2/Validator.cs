namespace Lab2
{
    public class Validator
    {
        public static bool IsValid(int N)
        {
            return N > 0 && N < 33;
        }

        public static bool IsEven(int N)
        {
            return N % 2 == 0;
        }

        public static void Validate(int N)
        {
            if (!IsValid(N))
            {
                throw new ArgumentException("N must be a natural number less than 33.");
            }

            if (!IsEven(N))
            {
                throw new ArgumentException("N must be an even number.");
            }
        }
    }
}
