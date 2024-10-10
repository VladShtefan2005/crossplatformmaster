namespace Lab3
{
    public class NegativeCycleDetector
    {
        public bool HasNegativeCycle(int[,] graph, int vertexCount)
        {
            int[] distances = new int[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[0] = 0;

            for (int i = 0; i < vertexCount - 1; i++)
            {
                for (int u = 0; u < vertexCount; u++)
                {
                    for (int v = 0; v < vertexCount; v++)
                    {
                        if (graph[u, v] != 100000 && distances[u] != int.MaxValue &&
                            distances[u] + graph[u, v] < distances[v])
                        {
                            distances[v] = distances[u] + graph[u, v];
                        }
                    }
                }
            }

            for (int u = 0; u < vertexCount; u++)
            {
                for (int v = 0; v < vertexCount; v++)
                {
                    if (graph[u, v] != 100000 && distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        return true; 
                    }
                }
            }

            return false; 
        }
    }
}

