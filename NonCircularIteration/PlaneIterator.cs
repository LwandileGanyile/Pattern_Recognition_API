using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace NonCircularIteration
{
    public class PlaneIterator<T> : Iterator<T>
    {
        public PlaneIterator()
        : base()
        {

        }

        public PlaneIterator(int currentIndex, DoubleLinkedList<T> doubleLinkedList)
        : base(currentIndex, doubleLinkedList)
        {

        }
    }
}
