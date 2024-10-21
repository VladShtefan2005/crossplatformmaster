namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = File.ReadAllText("Input.txt");

                (long petyaCoins, long vasyaCoins) = Logic.Process(input);

                File.WriteAllText("Output.txt", $"{petyaCoins} {vasyaCoins}");

                Console.WriteLine($"Petya's coins: {petyaCoins}, Vasya's coins: {vasyaCoins}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}