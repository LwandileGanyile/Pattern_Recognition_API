using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularIteration
{
    public interface IFunctionIterator<T>
    {
        FunctionIterator<T> RetrieveFunctionIterator();
    }
}
