using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonCircularIteration
{
    public interface IPointIterator<T>
    {
        PointIterator<T> RetrievePointIterator();
    }
}
