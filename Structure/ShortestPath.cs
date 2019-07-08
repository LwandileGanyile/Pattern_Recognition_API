using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // An inner class in the weighted graph.
    public class ShortestPathTree<E> : Tree<E>
    {

        // cost[v] is a cost from v to source.
        private float[] cost;

        public ShortestPathTree(List<E> vertices,int source, int[] parent, List<int> searchOrder, float[] cost)
        : base(vertices, source, parent, searchOrder)
        {
            
                this.cost = cost;
        }

        // Get the cost from the root to v.
        public double GetCost(int v)
        {

            return cost[v];
        }

        // Print paths from all the vertices to the source.
        public void PrintAllPaths()
        {

            Console.WriteLine("All shortest paths from " + vertices[(GetRoot())] + " are :");
            for (int i = 0; i < cost.Count(); i++)
            {
                PrintPath(i); // A path from i to source.
                Console.WriteLine("(cost: " + cost[i] + ")"); // Path cost.
            }

        }
    }

}
