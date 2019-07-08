using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public abstract class MyLinkedList<T> : IMyLinkedList<T>
    {
        protected int size;

        protected MyLinkedList()
        {
            size = 0;
        }

        protected MyLinkedList(T[] objects)
        {
            for (int index = 0; index < objects.Length; index++)
                Add(objects[index]);
        }

        protected MyLinkedList(List<T> objects)
        {
            for (int index = 0; index < objects.Count; index++)
                AddLast(objects[index]);
        }

        public abstract void Add(T element, int elementIndex);
        public abstract void AddFirst(T element);
        public abstract void AddLast(T element);


        public abstract T GetFirst();
        public abstract T GetAt(int index);
        public abstract T GetLast();

        public abstract void DisplayList();



        public abstract T Remove(int elementIndex);
        public abstract T RemoveFirst();
        public abstract T RemoveLast();

        public int Size
        {
            get { return size; }

        }

        public void Add(T element)
        {
            Add(element, size);
        }

        public void Clear()
        {
            while (!IsEmpty())
            {
                RemoveFirst();
            }
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

    }
}
