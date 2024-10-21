
namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var (graph, vertexCount) = Graph.ReadGraph("Input.txt");

                var detector = new NegativeCycleDetector();
                bool hasNegativeCycle = detector.HasNegativeCycle(graph, vertexCount);

                File.WriteAllText("Output.txt", hasNegativeCycle ? "YES" : "NO");
                if (hasNegativeCycle == true)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

