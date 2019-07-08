using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class WeightedGraph<E> : AbstractGraph<E>{

        // Priority Adjacency lists.
        private List<PriorityQueue<WeightedEdge>> queues = new List<PriorityQueue<WeightedEdge>>();

        public WeightedGraph()
        {

        }

        public WeightedGraph(int[][] edges, E[] vertices)
        : base(edges, vertices)
        {
            CreatePriorityQueues(edges, vertices.Count());
        }

        public WeightedGraph(int[][] edges, int numberOfVertices)
        : base(edges, numberOfVertices)
        {
            CreatePriorityQueues(edges, numberOfVertices);
        }
        // Uses WeightedEdge not Edge.
        public WeightedGraph(List<Edge> edges, List<E> vertices)
        : base(edges, vertices)
        {

            CreatePriorityQueues(edges, vertices.Count);
        }

        // Uses WeightedEdge not Edge.
        public WeightedGraph(List<Edge> edges, int numberOfVertices)
        : base(edges, numberOfVertices)
        {

            CreatePriorityQueues( edges, numberOfVertices);
        }

        // Create priority list from edge array.
        private void CreatePriorityQueues(int[][] edges, int numberOfVertices)
        {

            for (int i = 0; i < numberOfVertices; i++)
                queues.Add(new PriorityQueue<WeightedEdge>());

            for (int i = 0; i < edges.Count(); i++)
            {

                int u = edges[i][0];
                int v = edges[i][1];
                int weight = edges[i][2];

                // Insert an edge to a PriorityQueue.
                queues[u].Enqueue(new WeightedEdge(u, v, weight));
            }
        }

        // Create priority list from edge list.
        private void CreatePriorityQueues(List<Edge> edges, int numberOfVertices)
        {

            for (int i = 0; i < numberOfVertices; i++)
                queues.Add(new PriorityQueue<WeightedEdge>());

            foreach (WeightedEdge edge in edges)
                // Insert an edge to a PriorityQueue.
                queues[edge.u].Enqueue(edge);
        }

        // Display edges with weights.
        public void PrintWeightedEdges()
        {

            for (int i = 0; i < queues.Count; i++)
            {
                Console.Write(GetVertex(i) + " (" + i + "): ");

                PriorityQueue<WeightedEdge> queue = queues[i];

                for (int j = 0; j < queue.Count(); j++)
                {
                    WeightedEdge edge = queue[j];
                    Console.Write("(" + edge.u + ", " + edge.v + ", " + edge.weight + ") ");
                }
                Console.WriteLine();
            }
        }

        public List<PriorityQueue<WeightedEdge>> GetWeightedEdges()
        {

            return queues;
        }

        public new void Clear()
        {

            vertices.Clear();
            neighbors.Clear();
            queues.Clear();
        }

        public MinimumSpanningTree<E> GetMinimumSpinningTree()
        {

            return GetMinimumSpinningTree(0);
        }

        // Create and return a minimum spinning tree.
        public MinimumSpanningTree<E> GetMinimumSpinningTree(int startingVertex)
        {

            List<int> tree = new List<int>();

            // Initially the tree contains a starting vertex.
            tree.Add(startingVertex);

            int numberOfVertices = vertices.Count;
            int[] parent = new int[numberOfVertices];

            // Initially set the parent of all vertices to -1.
            for (int i = 0; i < parent.Count(); i++)
                parent[i] = -1;

            float totalWeight = 0;

            // Clone the priority PriorityQueue, so to keep the original PriorityQueue intact.
            List<PriorityQueue<WeightedEdge>> PriorityQueues = DeepClone(queues);

            // Check whether all vertices are found.
            while (tree.Count < numberOfVertices)
            {

                //Search for the vertex with the smallest edge adjacent to a vertex in a minimumSpinningTree.
                int v = -1;
                float smallestWeight = float.MaxValue;

                foreach (int u in tree)
                {

                    while (!(queues[u].Count() == 0) && tree.Contains(PriorityQueues[u].Peek().v))
                    {
                        // Remove the edge from PriorityQueues[u] if the adjacent vertex of u is already in tree.
                        // I doubt this the deque method.
                        PriorityQueues[u].Dequeue();
                    }

                    if (queues[u].Count() == 0)
                        continue; // Consider the next vertex in tree.

                    WeightedEdge edge = PriorityQueues[u].Peek();

                    if (edge.weight < smallestWeight)
                    {
                        v = edge.v;
                        smallestWeight = edge.weight;
                        // If v is added to tree, u will be its parent.
                        parent[v] = u;
                    }
                }

                if (v != -1)
                    tree.Add(v);
                else
                    break;

                totalWeight += smallestWeight;
            }

            return new MinimumSpanningTree<E>(vertices, startingVertex, parent, tree, totalWeight);
        }

        // Find single-source shortest paths.
        public ShortestPathTree<E> GetShortestPath(int sourceVertex)
        {

            // T contains the vertices of paths found so far.
            List<int> T = new List<int>();

            // T initially contains the source vertex.
            T.Add(sourceVertex);

            int numberOfVertices = vertices.Count;

            // parent[v] stores the previous vertex of v in the path.
            int[] parent = new int[numberOfVertices];
            parent[sourceVertex] = -1;

            // cost[v] stores the cost of the path from v to the source.
            float[] cost = new float[numberOfVertices];
            for (int i = 0; i < cost.Count(); i++)
                cost[i] = float.MaxValue;

            // Cost of source is 0.
            cost[sourceVertex] = 0;

            // Get a copy of PriorityQueues.
            List<PriorityQueue<WeightedEdge>> PriorityQueues = DeepClone(queues);

            // Expand T
            while (T.Count < numberOfVertices)
            {

                int v = -1; // Vertex to be determined.
                float smallestCost = float.MaxValue; // Set to infinity.

                foreach (int u in T)
                {
                    while (!(queues[u].Count()==0) && T.Contains(PriorityQueues[u].Peek().v))
                    {
                        // Remove the vertex in PriorityQueue for u.
                        // We suppose to remove an edge with minimum weight.
                        PriorityQueues[u].Dequeue();
                    }

                    if (queues[u].Count()==0)
                        continue; // All vertices adjacent to u are in T.

                    WeightedEdge edge = PriorityQueues[u].Peek();
                    if (cost[u] + edge.weight < smallestCost)
                    {
                        v = edge.v;
                        smallestCost = cost[u] + edge.weight;
                        parent[v] = u; // If v is added to the tree, u will be its parent.
                    }
                }

                T.Add(v); // Add a new vertex to T.
                cost[v] = smallestCost;

            }

            return new ShortestPathTree<E>(vertices,sourceVertex, parent, T, cost);
        }
       
        // Clone an array of PriorityQueues.
        private List<PriorityQueue<WeightedEdge>> DeepClone(List<PriorityQueue<WeightedEdge>> PriorityQueues)
        {

            List<PriorityQueue<WeightedEdge>> copiedPriorityQueues = new List<PriorityQueue<WeightedEdge>>();

            for (int i = 0; i < queues.Count; i++)
            {
                copiedPriorityQueues.Add(new PriorityQueue<WeightedEdge>());

                PriorityQueue<WeightedEdge> queue = queues[i];

                for (int j = 0; j < queue.Count();j++)
                {
                    copiedPriorityQueues[i].Enqueue(queue[j]);

                }
            }

            return copiedPriorityQueues;
        }

        public new void AddVertex(E vertex)
        {

            base.AddVertex(vertex);
            queues.Add(new PriorityQueue<WeightedEdge>());
        }

        public void AddEdge(int u, int v, float weight)
        {

            AddEdge(u, v);
            queues[u].Enqueue(new WeightedEdge(u, v, weight)); // We must find the add equivalent method.
            queues[v].Enqueue(new WeightedEdge(v, u, weight)); // We must find the add equivalent method.
        }

    }

}
