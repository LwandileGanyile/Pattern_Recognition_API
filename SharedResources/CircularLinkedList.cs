using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public class CircularLinkedList<T> : MyLinkedList<T>
    {
        private MyNode<T> _head;


        public CircularLinkedList()
        {
            _head = null;
        }

        public CircularLinkedList(T[] objects) : base(objects)
        {


        }

        public CircularLinkedList(List<T> objects) : base(objects)
        {


        }

        public override void Add(T element, int elementIndex)
        {
            if (elementIndex <= 0)
                AddFirst(element);
            else if (elementIndex >= size)
                AddLast(element);
            else
            {
                MyNode<T> current = _head;

                for (int index = 1; index < elementIndex; index++)
                    current = current.next;

                MyNode<T> temp = current.next;
                current.next = new MyNode<T>(element);
                (current.next).next = temp;
                size++;
            }
        }

        public override void DisplayList()
        {
            MyNode<T> current = _head;

            for (int i = 1; i <= size; i++)
            {
                if (current != null)
                {
                    Console.Write(current.element + " ");
                    current = current.next;
                }

            }

        }

        public override string ToString()
        {
            MyNode<T> current = _head;

            string output = "";

            for (int i = 1; i <= size; i++)
            {
                if (current != null)
                {
                    output += (current.element + " ");
                    current = current.next;
                }

            }

            return output;

        }

        public override void AddFirst(T element)
        {
            MyNode<T> newNode = new MyNode<T>(element);
            if (_head == null)
                _head = newNode;
            else
            {
                MyNode<T> temp = _head;
                _head = newNode;
                newNode.next = temp;

            }
            size++;
        }

        public override void AddLast(T element)
        {
            MyNode<T> lastNode = _head;

            for (int i = 0; i < size; i++)
            {
                if (lastNode.next != null)
                    lastNode = lastNode.next;
            }

            lastNode.next = new MyNode<T>(element);

            size++;
        }

        public override T GetFirst()
        {
            return _head.element;
        }

        public override T GetLast()
        {

            MyNode<T> current = _head;

            for (int i = 0; i < size - 1; i++)
                current = current.next;

            return current.element;
        }

        public override T Remove(int elementIndex)
        {

            if (elementIndex <= 0)
            {
                return RemoveFirst();
            }
            else if (elementIndex >= size - 1)
            {
                return RemoveLast();
            }
            else
            {
                MyNode<T> prev = _head;

                for (int i = 1; i < elementIndex; i++)
                {
                    prev = prev.next;
                }

                MyNode<T> current = prev.next;
                prev.next = current.next;
                size--;

                return current.element;
            }
        }

        public override T RemoveFirst()
        {
            if (size == 0)
            {
                return _head.element;
            }
            else
            {
                MyNode<T> temp = _head; // Keep the first node temporarily.
                _head = _head.next; // Move head to point to the next node.
                size--; // Reduce size by 1.

                return temp.element;
            }
        }

        public override T RemoveLast()
        {
            if (size == 0)
            {
                return RemoveFirst();
            }
            else if (size == 1)
            {
                MyNode<T> temp = _head;
                _head = null;
                size = 0;
                return temp.element;
            }
            else
            {
                MyNode<T> current = _head;

                for (int i = 0; i < size - 2; i++)
                {
                    current = current.next;
                }

                MyNode<T> temp = current.next;
                size--;
                return temp.element;
            }
        }

        public override T GetAt(int atElement)
        {


            if (atElement <= 0)
                return GetFirst();
            else if (atElement >= size - 1)
                return GetLast();
            else
            {
                MyNode<T> current = _head;

                for (int i = 0; i < atElement; i++)
                    current = current.next;
                return current.element;
            }

        }


    }


}
