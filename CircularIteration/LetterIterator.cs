using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedResources;

namespace CircularIteration
{
    public class LetterIterator<T> : Iterator<T>
    {


        public LetterIterator()
        {

        }

        public LetterIterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        : base(currentIndex, circularLinkedList)
        {

        }


    }
}
