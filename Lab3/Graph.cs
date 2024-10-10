namespace Lab3
{
    public class Graph
    {
        public static (int[,], int) ReadGraph(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int vertexCount = int.Parse(lines[0].Trim());
            int[,] graph = new int[vertexCount, vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                string[] weights = lines[i + 1].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < vertexCount; j++)
                {
                    graph[i, j] = int.Parse(weights[j]);
                }
            }

            return (graph, vertexCount);
        }
    }
}