Graph g = new Graph(10);
g.AddEdge("San José", "Cartago", 45);
g.AddEdge("Cartago", "Paraíso", 15);
g.AddEdge("Liberia", "Cañas", 65);

Dijkstra.Run(g, g.IndexOf("San José"), out int[] dist, out int[] prev);

for (int i = 0; i < g.VertexCount; i++)
{
    if (dist[i] == Dijkstra.Infinity)
        Console.WriteLine(g.GetName(i) + ": inalcanzable");
    else
        Console.WriteLine(g.GetName(i) + ": " + dist[i] + " min");
}