using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace NonCircularIteration
{
    public class FunctionIterator<T> : Iterator<T>
    {
        public FunctionIterator()
        : base()
        {

        }

        public FunctionIterator(int currentIndex, DoubleLinkedList<T> doubleLinkedList)
        : base(currentIndex, doubleLinkedList)
        {

        }
    }
}
