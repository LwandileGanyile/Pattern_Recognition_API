using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // MST is an inner class in WeightedCraph
    public class MinimumSpanningTree<E> : Tree<E>
    {

        // Total weight of the tree's edges.
        private float totalWeight;

        public MinimumSpanningTree(List<E> vertices, int root, int[] parent, List<int> searchOrder, float totalWeight)
        : base(vertices,root, parent, searchOrder)
        {
            this.totalWeight = totalWeight;
        }

        public float GetTotalWeight()
        {

            return totalWeight;
        }
    }
}
