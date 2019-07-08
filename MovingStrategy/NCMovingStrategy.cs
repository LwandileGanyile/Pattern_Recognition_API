using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using NonCircularIteration;

namespace MovingStrategy
{
    public abstract class NCMovingStrategy<T, U> : NonCircular<T, U>
    {
        protected NCMovingStrategy()
        : base()
        {

        }

        protected NCMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int numberOfRepeatations)
        : base(_startingPoint, direction,
        duration, numberOfRepeatations)
        {

        }

        protected NCMovingStrategy(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRepeatations)
        : base(_startingPoint, direction,
        canShootList, duration, numberOfRepeatations)
        {

        }



    }
}
