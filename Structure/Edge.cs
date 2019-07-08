using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // Edge inner class within the AbstractGraph class.
    public class Edge : IEdge
    {

        public int u;
        public int v;

        public Edge(int u, int v)
        {
            this.v = v;
            this.u = u;
        }
    }
}
