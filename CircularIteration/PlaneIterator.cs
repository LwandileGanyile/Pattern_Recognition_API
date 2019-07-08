using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace CircularIteration
{
    public class PlaneIterator<T> : Iterator<T>
    {
        public PlaneIterator()
        {

        }

        public PlaneIterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }
    }
}
