using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public interface IGraph<E>
    {

        // Return number of vertices in a graph.
        int GetSize();

        // Return the vertices in a graph.	
        List<E> GetVertices();

        // Return the index for the specified vertex object.
        int GetIndex(E e);

        // Return the object for the specified index vertex.	
        E GetVertex(int index);

        // Return the neighbors of vertex with the specified index.
        List<int> GetNeighbors(int index);

        // Return the degree for a specified vertex index.
        int GetDegree(int index);
        // Print Edges.
        void PrintEdges();
        // Clear graph.
        void Clear();

        // Add vertex
        void AddVertex(E e);

        // Add edge.
        void AddEdge(int u, int v);

        // Return a depthFirstSearch spanning tree starting from vertex index v.
        Tree<E> DepthFirstSearch(int v);

        // Return a breathFirstSearch spanning tree starting from vertex index v.
        Tree<E>  BreathFirstSearch(int v);


    }

}
