using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;
using Pieces;

namespace ShootingStrategy
{
    public abstract class NonCircularShootingStrategy<T, U> : NonCircular<T, U>, IShootingStrategy
    {
        public NonCircularShootingStrategy()
        {

        }

        public NonCircularShootingStrategy(List<U> shootingStrategy)
        {

        }

        public NonCircularShootingStrategy(Point startingPioint, Shoot shoot)
        {

        }
    }
}
