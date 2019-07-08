using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class UnweightedGraph<E> : AbstractGraph<E>{


    public UnweightedGraph()
    {

    }

    public UnweightedGraph(int[][] edges, E[] vertices)
    :base(edges, vertices)
    {
        
    }

    public UnweightedGraph(List<Edge> edges, List<E> vertices)
    : base(edges, vertices)
    {
       
    }

    public UnweightedGraph(int[][] edges, int numberOfVertices)
    : base(edges, numberOfVertices)
    {
        
    }

    public UnweightedGraph(List<Edge> edges, int numberOfVertices)
    : base(edges, numberOfVertices)
    {
        
    }
}
}
