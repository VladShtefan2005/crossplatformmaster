namespace Lab3
{
    public class Validator
    {
        public static void ValidateInput(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                throw new InvalidOperationException("Empty input file.");
            }

            int vertexCount = int.Parse(lines[0]);
            if (vertexCount < 1 || vertexCount > 100)
            {
                throw new InvalidOperationException("Number of vertices must be between 1 and 100.");
            }

            for (int i = 1; i <= vertexCount; i++)
            {
                string[] weights = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (weights.Length != vertexCount)
                {
                    throw new InvalidOperationException($"Row {i} does not contain the correct number of weights.");
                }

                foreach (var weight in weights)
                {
                    int w = int.Parse(weight);
                    if (w < -10000 || w > 10000)
                    {
                        throw new InvalidOperationException("Edge weights must be between -10000 and 10000.");
                    }
                }
            }
        }
    }
}
