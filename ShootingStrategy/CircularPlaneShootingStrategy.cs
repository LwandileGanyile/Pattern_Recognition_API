using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStrategy
{
    public abstract class CircularPlaneShootingStrategy<T, U> : CircularShootingStrategy<T, U>
    {
        protected PlaneShootingStrategy shootingStrategy;

        protected CircularPlaneShootingStrategy()
        {

        }

        protected CircularPlaneShootingStrategy(PlaneShootingStrategy shootingStrategy)
        {

        }




    }
}
