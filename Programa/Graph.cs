public class Graph
{
    public const int NoEdge = -1;   // no hay camino directo si esta en -1

    private string[] names;         // lista con los nombres
    private int[,] matrix;          // la tabla de tiempos
    private int count;              // cantidad de lugares qu hay

    public Graph(int capacity = 2) 
    // lo de la capacidad es para poner la cantidad
    // de ubicaciones minimas que habra
    {
        names = new string[capacity];
        matrix = new int[capacity, capacity];
        for (int i = 0; i < capacity; i++)
            for (int j = 0; j < capacity; j++)
                matrix[i, j] = NoEdge;
                // porque al inicio no hay ningún camino
        count = 0;
    }

    public int VertexCount => count;

    public string GetName(int index) => names[index];

    public int GetWeight(int i, int j) => matrix[i, j];

    // Devuelve el número del lugar, o -1 si no existe
    public int IndexOf(string name)
    {
        for (int i = 0; i < count; i++)
            if (names[i] == name) return i;
        return -1;
    }

    // Agrega el lugar si no existe y devuelve su numero
    public int AddVertex(string name)
    {
        int existing = IndexOf(name);
        if (existing != -1) return existing;
        names[count] = name;
        count++;
        return count - 1;
    }

    // Agregar un camino de ida y vuelta
    public void AddEdge(string a, string b, int minutes)
    {
        int i = AddVertex(a);
        int j = AddVertex(b);
        matrix[i, j] = minutes;
        matrix[j, i] = minutes;
    }
}