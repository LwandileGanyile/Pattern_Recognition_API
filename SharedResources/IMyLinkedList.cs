using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public interface IMyLinkedList<T>
    {
        void AddFirst(T element);
        void AddLast(T element);
        void Add(T element);

        T GetFirst();
        T GetLast();
        T GetAt(int atElement);

        void DisplayList();


        T RemoveFirst();
        T RemoveLast();

        void Add(T element, int elementIndex);
        T Remove(int elementIndex);

        bool IsEmpty();
        void Clear();
    }
}
