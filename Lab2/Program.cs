namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int N = FileHandler.ReadInput();
                Validator.Validate(N); 

                int result = Logic.CalculateWays(N);
                FileHandler.WriteOutput(result);

                Console.WriteLine($"The number of ways to divide a 3x{N} chocolate bar: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
