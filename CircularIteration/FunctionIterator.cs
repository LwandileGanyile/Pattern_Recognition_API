using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace CircularIteration
{
    public class FunctionIterator<T> : Iterator<T>
    {
        public FunctionIterator()
        {

        }

        public FunctionIterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }
    }
}
