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
        protected int numberOfRotations;

        protected Circular()
        : base()
        {
            numberOfRotations = 2;
            linkedList = new CircularLinkedList<U>();
        }

        // Construct without using the can shoot property.
        protected Circular(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int numberOfRotations)
        : base(_startingPoint, direction,
        duration)
        {

            this.numberOfRotations = numberOfRotations;
            linkedList = new CircularLinkedList<U>();

        }

        // Construct using all properties.
        protected Circular(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration, int numberOfRotations)
        : base(_startingPoint, direction, canShootList, duration)
        {

            this.numberOfRotations = numberOfRotations;
            linkedList = new CircularLinkedList<U>();

        }

        public int NumberOfRotations
        {
            set;
            get;
        }

        public override string ToString()
        {
            return base.ToString() + "\nRotations how many times? " + numberOfRotations + "\n" + linkedList.ToString();
        }
    }
}
