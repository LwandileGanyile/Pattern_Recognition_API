using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedResources;

namespace CircularIteration
{
    public class PointIterator<T> : Iterator<T>
    {


        public PointIterator()
        {

        }

        public PointIterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }


    }
}
