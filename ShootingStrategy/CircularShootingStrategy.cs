using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;
using Pieces;

namespace ShootingStrategy
{
    public abstract class CircularShootingStrategy<T, U> : Circular<T, U>, IShootingStrategy
    {

        public CircularShootingStrategy()
        {

        }

        public CircularShootingStrategy(List<U> shootingStrategy)
        {

        }

        public CircularShootingStrategy(Point startingPioint, Shoot shoot)
        {

        }


    }
}
