using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // Tree inner class within the AbstractGraph class.
    public class Tree<E>
    {

        private int root;
        private int[] parents;
        private List<int> searchOrder;
        protected List<E> vertices = new List<E>(); // Vertices

        public Tree(List<E> vertices)
        {
            root = -1;
            parents = null;
            searchOrder = null;
            this.vertices = vertices;
        }

        public Tree(List<E> vertices,int root, int[] parents, List<int> searchOrder)
        {
            this.vertices = vertices;
            this.root = root;
            this.parents = parents;
            this.searchOrder = searchOrder;
        }

        public int GetRoot() { return root; }

        public int GetParent(int v) { return parents[v]; }

        public List<int> GetSearchOrder() { return searchOrder; }

        public int GetNumberOfVerticesFound() { return searchOrder.Count; }

        public void PrintTree()
        {
            Console.WriteLine("Root is : " + vertices[root]);
            Console.Write("Edges : ");

            for (int i = 0; i < parents.Count(); i++)
            {
                if (parents[i] != -1)
                {
                    //Display an edge.
                    Console.Write("(" + vertices[parents[i]] + "," + vertices[i] + ")");
                }
            }
            Console.WriteLine();
        }

        public void PrintPath(int index)
        {

            List<E> path = GetPath(index);
            Console.Write("A path from " + vertices[root] + " to" + vertices[index] + " : ");

            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.Write(path[i] + " ");
            }
        }

        public List<E> GetPath(int index)
        {

            List<E> path = new List<E>();

            do
            {
                path.Add(vertices.ElementAt(index));
                index = parents[index];
            } while (index != -1);

            return path;
        }
    }
}
