public static class Dijkstra
{
    public const int Infinity = int.MaxValue;   // significa "inalcanzable"

    // dist[i] = minutos mínimos desde 'source' hasta el lugar i
    // prev[i] = de qué lugar se viene para llegar a i (sirve para reconstruir la ruta)
    public static void Run(Graph g, int source, out int[] dist, out int[] prev)
    {
        int n = g.VertexCount;
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = Infinity;
            prev[i] = -1;
        }
        dist[source] = 0;

        for (int step = 0; step < n; step++)
        {
            // Paso 2: buscar el lugar no revisado con menor tiempo
            int u = -1;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] || dist[i] == Infinity) continue;
                if (u == -1 || dist[i] < dist[u]) u = i;
            }
            if (u == -1) break;      // los que quedan no se pueden alcanzar
            visited[u] = true;

            // Paso 3: revisar los vecinos de u
            for (int v = 0; v < n; v++)
            {
                int w = g.GetWeight(u, v);
                if (w == Graph.NoEdge || visited[v]) continue;

                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    prev[v] = u;
                }
            }
        }
    }
}