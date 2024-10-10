namespace Lab1
{
    public static class Validator
    {
        public static bool ValidateInput(string input, out int N, out int K1, out int K2, out long S)
        {
            N = 0;
            K1 = 0;
            K2 = 0;
            S = 0;

            string[] parts = input.Split(' ');

            if (parts.Length != 4)
            {
                Console.WriteLine("Некоректний формат вводу. Введіть чотири цілі числа.");
                return false;
            }

            try
            {
                N = int.Parse(parts[0]);
                K1 = int.Parse(parts[1]);
                K2 = int.Parse(parts[2]);
                S = long.Parse(parts[3]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректний формат вводу. Введіть цілі числа.");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введене число занадто велике.");
                return false;
            }

            if (N < 1 || N > 50 || K1 < 0 || K1 >= N || K2 < 0 || K2 >= N || S <= 1 || S >= Math.Pow(10, 100))
            {
                Console.WriteLine("Некоректні вхідні дані.");
                return false;
            }

            return true;
        }
    }
}
