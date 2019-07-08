using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using CircularIteration;

namespace MovingStrategy
{
    public abstract class CMovingStrategy<T, U> : Circular<T, U>
    {

        protected CMovingStrategy()
        : base()
        {

        }

        protected CMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int numberOfRotations)
        : base(_startingPoint, direction,
        duration, numberOfRotations)
        {

        }

        protected CMovingStrategy(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration, int numberOfRotations)
        : base(_startingPoint, direction,
        canShootList, duration, numberOfRotations)
        {

        }
    }
}
