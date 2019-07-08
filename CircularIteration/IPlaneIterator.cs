using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularIteration
{
    public interface IPlaneIterator<T>
    {
        PlaneIterator<T> RetrievePlaneIterator();
    }
}
