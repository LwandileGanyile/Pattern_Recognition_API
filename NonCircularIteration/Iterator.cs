using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using SharedResources;

namespace NonCircularIteration
{
    public abstract class Iterator<T> : IBiIDirectionalIterator<T>
    {
        protected int currentIndex;
        protected DoubleLinkedList<T> linkedList;

        protected Iterator()
        {

        }

        protected Iterator(int currentIndex, DoubleLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
            this.currentIndex = currentIndex;
        }

        public T GetNext()
        {

            if (currentIndex != -1 && currentIndex < linkedList.Size)
            {
                T toReturn = linkedList.GetAt(currentIndex);
                currentIndex = currentIndex + 1;
                return toReturn;
            }

            return default(T);
        }

        public bool HasNext()
        {

            return currentIndex < linkedList.Size;
        }

        public T Remove()
        {

            if (currentIndex != -1)
            {
                return linkedList.Remove((currentIndex + 1) % linkedList.Size);
            }

            return default(T);
        }

        public bool HasPrevious()
        {
            return currentIndex > 0;

        }

        public T GetPrevious()
        {
            if (currentIndex > 0)
                return linkedList.GetAt(currentIndex - 1);
            return default(T);
        }
    }
}
