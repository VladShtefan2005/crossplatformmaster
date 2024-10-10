namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("Input.txt");

            (long petyaCoins, long vasyaCoins) = Logic.Process(input);

            File.WriteAllText("Output.txt", $"{petyaCoins} {vasyaCoins}");
            
            Console.WriteLine($"Petya's coins: {petyaCoins}, Vasya's coins: {vasyaCoins}");
        }
    }
}