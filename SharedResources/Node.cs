using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public class Node<T>
    {
        public T element;
        public Node<T> next;
        public Node<T> previous;

        public Node()
        {
            element = default(T);
            next = null;
            previous = null;
        }

        public Node(T element)
        {
            this.element = element;
            next = null;
            previous = null;
        }

    }
}
