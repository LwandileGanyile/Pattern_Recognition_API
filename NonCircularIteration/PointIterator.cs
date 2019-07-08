using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace NonCircularIteration
{
    public class PointIterator<T> : Iterator<T>
    {

        public PointIterator()
        {

        }

        public PointIterator(int currentIndex, DoubleLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }


    }
}
