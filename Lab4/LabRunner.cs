public static class LabRunner
{
    public static string RunLab1(string input)
    {
        try
        {
            (long petyaCoins, long vasyaCoins) = Lab1.Logic.Process(input);

            return $"Petya's coins: {petyaCoins}, Vasya's coins: {vasyaCoins}";
        }
        catch (FileNotFoundException ex)
        {
            return $"File not found: {ex.Message}";
        }
        catch (FormatException ex)
        {
            return $"Invalid format: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }
    }

    public static string RunLab2(string input)
    {
        try
        {
            int N = int.Parse(input);

            Lab2.Validator.Validate(N);

            int result = Lab2.Logic.CalculateWays(N);

            return $"The number of ways to divide a 3x{N} chocolate bar: {result}";
        }
        catch (ArgumentException ex)
        {
            return $"Invalid input: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }
    }

    public static string RunLab3(string input)
    {
        try
        {
            string filePath = "Lab3/Input.txt";  
            Lab3.Validator.ValidateInput(filePath);

            var (graph, vertexCount) = Lab3.Graph.ReadGraph(filePath);

            var detector = new Lab3.NegativeCycleDetector();
            bool hasNegativeCycle = detector.HasNegativeCycle(graph, vertexCount);

            string result = hasNegativeCycle ? "YES" : "NO";

            File.WriteAllText("Output.txt", result);

            return result;
        }
        catch (InvalidOperationException ex)
        {
            return $"Input validation error: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }
    }

}
