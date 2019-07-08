using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace NonCircularIteration
{
    public class LetterIterator<T> : Iterator<T>
    {

        public LetterIterator()
         : base()
        {

        }

        public LetterIterator(int currentIndex, DoubleLinkedList<T> doubleLinkedList)
        : base(currentIndex, doubleLinkedList)
        {

        }


    }
}
