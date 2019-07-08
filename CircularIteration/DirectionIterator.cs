using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using SharedResources;


namespace CircularIteration
{
    public class DirectionIterator<T> : Iterator<T>
    {
        public DirectionIterator()
        {

        }

        public DirectionIterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }


    }
}
