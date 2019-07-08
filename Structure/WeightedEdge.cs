using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class WeightedEdge : Edge, IComparable<WeightedEdge>{

    // The weight on edge (u,v)
    public float weight;

    public WeightedEdge(int u, int v, float weight)
    : base(u,v)
    {
        this.weight = weight;
    }

    public int CompareTo(WeightedEdge edge)
    {

        if (weight > edge.weight)
            return 1;
        else if (weight < edge.weight)
            return -1;
        return 0;
    }


}
}
