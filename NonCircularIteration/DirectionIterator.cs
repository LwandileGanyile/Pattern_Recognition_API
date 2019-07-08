using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace NonCircularIteration
{
    public class DirectionIterator<T> : Iterator<T>
    {
        public DirectionIterator()
         : base()
        {

        }

        public DirectionIterator(int currentIndex, DoubleLinkedList<T> doubleLinkedList)
        : base(currentIndex, doubleLinkedList)
        {

        }
    }
}
