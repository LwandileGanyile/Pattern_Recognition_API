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
        protected int numberOfRepeatations;

        public NonCircular()
        : base()
        {
            numberOfRepeatations = 2;
            linkedList = new DoubleLinkedList<U>();
        }

        // Construct without using the can shoot property.
        protected NonCircular(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int numberOfRepeatations)
        : base(_startingPoint, direction, duration)
        {

            this.numberOfRepeatations = numberOfRepeatations;
            linkedList = new DoubleLinkedList<U>();

        }

        // Construct using all attributes.
        protected NonCircular(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration, int numberOfRepeatations)
        : base(_startingPoint, direction,
        canShootList, duration)
        {
            this.numberOfRepeatations = numberOfRepeatations;
            linkedList = new DoubleLinkedList<U>();
        }

        public int NumberOfRepeatations
        {
            set;
            get;
        }

        public override string ToString()
        {
            return base.ToString() + "\nRepeatations how many times? " + numberOfRepeatations + "\n" + linkedList.ToString();
        }
    }
}
