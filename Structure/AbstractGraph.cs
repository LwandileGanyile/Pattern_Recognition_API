using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public abstract class AbstractGraph<E> : IGraph<E>{


    protected List<E> vertices = new List<E>(); // Vertices
                                                    // Adjacency list
    protected List<List<int>> neighbors = new List<List<int>>();

    protected AbstractGraph()
    {

    }

   protected AbstractGraph(int[][] edges, E[] vertices)
    {

        for (int i = 0; i < vertices.Count(); i++)
            this.vertices.Add(vertices[i]);

        CreateAjacencyList(edges, vertices.Count());
    }


    protected AbstractGraph(int[][] edges, int numberOfVertices)
    {

        for (int i = 0; i < numberOfVertices; i++)
            vertices.Add((E)Convert.ChangeType(i, typeof(E)));
        CreateAjacencyList(edges, numberOfVertices);
    }

    protected AbstractGraph(List<Edge> edges, List<E> vertices)
    {

        for (int i = 0; i < vertices.Count; i++)
            this.vertices.Add(vertices[i]);
        CreateAjacencyList(edges, vertices.Count);
    }

    protected AbstractGraph(List<Edge> edges, int numberOfVertices)
    {

        for (int i = 0; i < numberOfVertices; i++)
            vertices.Add((E)Convert.ChangeType(i, typeof(E)));
        CreateAjacencyList(edges, numberOfVertices);
    }

    private void CreateAjacencyList(int[][] edges, int numberOfVertices)
    {

        // Initialize neighbors for each vertex.
        for (int i = 0; i < numberOfVertices; i++)
            neighbors.Add(new List<int>());

        for (int i = 0; i < numberOfVertices; i++)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            neighbors[u].Add(v);
        }
    }

    private void CreateAjacencyList(List<Edge> edges, int numberOfVertices)
    {

        // Initialize neighbors for each vertex.
        for (int i = 0; i < numberOfVertices; i++)
            neighbors.Add(new List<int>());

        foreach (Edge edge in edges)
            neighbors[edge.u].Add(edge.v);

    }
  
    public int GetSize()
    {

        return vertices.Count;
    }

    public List<E> GetVertices()
    {

        return vertices;
    }

    public int GetIndex(E e)
    {
        
        return vertices.IndexOf(e);
    }

    public E GetVertex(int index)
    {

        return vertices[index];
    }

    public List<int> GetNeighbors(int index)
    {

        return neighbors[index];
    }

    public int GetDegree(int v)
    {

        return neighbors[v].Count;
    }

    public void PrintEdges()
    {

        for (int u = 0; u < neighbors.Count; u++)
        {
            Console.Write(GetVertex(u) + " (" + u + "): ");
            for (int j = 0; j < neighbors[u].Count; j++)
            {
                    Console.Write("(" + u + "," + neighbors[u][j] + ")");
            }
                Console.WriteLine();
        }

    }

    public void Clear()
    {
        vertices.Clear();
        neighbors.Clear();
    }

    public void AddVertex(E e)
    {

        vertices.Add(e);
        neighbors.Add(new List<int>());
    }

    public void AddEdge(int u, int v)
    {

        neighbors[u].Add(v);
        neighbors[v].Add(u);
    }

    public Tree<E> DepthFirstSearch(int v)
    {

        List<int> searchOrder = new List<int>();
        int[] parents = new int[vertices.Count];

        // Initialize parents.
        for (int i = 0; i < parents.Count(); i++)
            parents[i] = -1;

        bool[] isVisited = new bool[vertices.Count];
        DepthFirstSearch(v, parents, searchOrder, isVisited);

        return new Tree<E>(vertices,v, parents, searchOrder);
    }

    private void DepthFirstSearch(int v, int[] parents, List<int> searchOrder, bool[] isVisited)
    {

        searchOrder.Add(v);
        isVisited[v] = true;

        foreach (int i in neighbors[v])
        {
            if (!isVisited[i])
            {
                parents[i] = v; // The parent of vertex i is v.
                DepthFirstSearch(i, parents, searchOrder, isVisited);
            }

        }
    }

    // Starting BFS search from v
    public Tree<E> BreathFirstSearch(int v)
    {

        List<int> searchOrder = new List<int>();
        int[] parents = new int[vertices.Count];

        // Initialize parents.
        for (int i = 0; i < parents.Count(); i++)
            parents[i] = -1;

        // List used as a queue.
        LinkedList<int> queue = new LinkedList<int>();
        bool[] isVisited = new bool[vertices.Count];

        queue.AddLast(v); // Enqueue v.
        isVisited[v] = true; // Mark it as visited.

        while (!(queue.Count==0))
        {
            int u = queue.First(); // Dequeue to u.
            searchOrder.Add(u); // u searched.
            foreach (int w in neighbors[u])
            {
                if (!isVisited[w])
                {
                    queue.AddLast(w); // Enqueue w.
                    parents[w] = u; // The parent of w is u.
                    isVisited[w] = true; // Mark w as visited.
                }
            }
        }

        return new Tree<E>(vertices,v, parents, searchOrder);

    }
}

}
