using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    public class MyNode<T>
    {
        public T element;
        public MyNode<T> next;

        public MyNode()
        {
            element = default(T);
            next = null;
        }

        public MyNode(T element)
        {
            this.element = element;
            next = null;
        }

    }
}
