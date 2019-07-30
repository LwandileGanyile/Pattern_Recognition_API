using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;

namespace SharedResources
{
    public abstract class NonCircular<T, U> : Parent<T, U>
    {
        public NonCircular()
        : base()
        {
            linkedList = new DoubleLinkedList<U>();
        }

        protected NonCircular(List<bool> canSwitchList, bool canSwitch,
        int numberOfTimes)
       : base(canSwitchList, canSwitch,numberOfTimes)
        {

            linkedList = new DoubleLinkedList<U>();

        }

        public override string ToString()
        {
            return base.ToString() + linkedList.ToString();
        }
    }
}
