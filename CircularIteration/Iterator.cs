using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using SharedResources;

namespace CircularIteration
{
    public abstract class Iterator<T> : IUniIDirectionalIterator<T>
    {
        protected int currentIndex;
        protected CircularLinkedList<T> linkedList;

        protected Iterator()
        {
            currentIndex = -1;
            linkedList = new CircularLinkedList<T>();
        }

        protected Iterator(int currentIndex, CircularLinkedList<T> circularLinkedList)
        {
            linkedList = circularLinkedList;
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
    }
}
