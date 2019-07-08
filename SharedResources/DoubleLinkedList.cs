using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharedResources
{

    public class DoubleLinkedList<T> : MyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public DoubleLinkedList()
        {
            _head = null;
            _tail = null;
        }

        public DoubleLinkedList(T[] objects) : base(objects)
        {

        }

        public DoubleLinkedList(List<T> objects) : base(objects)
        {

        }

        public override void DisplayList()
        {
            Node<T> current = _head;

            for (int i = 1; i <= size; i++)
            {
                if (current != null)
                {
                    Console.Write(current.element + " ");
                    current = current.next;
                }

            }

        }

        public override void Add(T element, int elementIndex)
        {

            if (elementIndex <= 0)
                AddFirst(element);
            else if (elementIndex >= size)
                AddLast(element);
            else
            {
                Node<T> current = _head;

                for (int index = 1; index < elementIndex; index++)
                    current = current.next;

                Node<T> temp = current.next;
                current.next = new Node<T>(element);
                (current.next).next = temp;
                size++;
            }

        }

        public override void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (_head == null)
                _head = _tail = newNode;
            else
            {
                Node<T> temp = _head;
                _head = newNode;
                newNode.next = temp;

            }
            size++;
        }

        public override void AddLast(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (_tail == null)
                _head = _tail = newNode;
            else
            {

                _tail.next = newNode;
                _tail = newNode;
            }
            size++;
        }

        public override T GetFirst()
        {
            return _head.element;
        }

        public override T GetLast()
        {
            return _tail.element;
        }

        public override T Remove(int elementIndex)
        {
            if (elementIndex < 0 || elementIndex >= size)
            {
                return default(T);
            }
            else if (elementIndex == 0)
            {
                return RemoveFirst();
            }
            else if (elementIndex == size - 1)
            {
                return RemoveLast();
            }
            else
            {
                Node<T> prev = _head;

                for (int i = 1; i < elementIndex; i++)
                {
                    prev = prev.next;
                }

                Node<T> current = prev.next;
                prev.next = current.next;
                size--;

                return current.element;
            }
        }

        public override T RemoveFirst()
        {
            if (size == 0)
            {
                return default(T);
            }
            else
            {
                Node<T> temp = _head.next; // Keep the first node temporarily.
                _head = _head.next; // Move head to point to the next node.
                size--; // Reduce size by 1.

                if (_head == null)
                    _tail = null; // List becomes empty.
                return temp.element;
            }
        }

        public override T RemoveLast()
        {
            if (size == 0)
            {
                return default(T);
            }
            else if (size == 1)
            {
                Node<T> temp = _head;
                _head = _tail = null;
                size = 0;
                return temp.element;
            }
            else
            {
                Node<T> current = _head;

                for (int i = 0; i < size - 2; i++)
                {
                    current = current.next;
                }

                Node<T> temp = _tail;
                _tail = current;
                _tail.next = null;
                size--;
                return temp.element;
            }

        }

        public override T GetAt(int atElement)
        {
            if (atElement == 0)
                return GetFirst();
            else if (atElement >= size - 1)
                return GetLast();
            else
            {
                Node<T> current = _head;

                for (int i = 0; i < atElement; i++)
                    current = current.next;
                return current.element;
            }

        }

        public override string ToString()
        {
            Node<T> current = _head;

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
    }
}
