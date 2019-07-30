using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;


namespace SharedResources
{
    public abstract class Circular<T, U> : Parent<T, U>
    { 

        protected Circular()
        : base()
        {
            linkedList = new CircularLinkedList<U>();
        }

        protected Circular(List<bool> canSwitchList, bool canSwitch,
        int numberOfTimes)
        : base(canSwitchList, canSwitch, numberOfTimes)
        {

            linkedList = new CircularLinkedList<U>();

        }

        public override string ToString()
        {
            return base.ToString() + linkedList.ToString();
        }
    }
}
