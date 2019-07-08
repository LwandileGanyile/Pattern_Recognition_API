using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStrategy
{
    public abstract class CircularVectorShootingStrategy<T, U> : CircularShootingStrategy<T, U>
    {
        protected VectorShootingStrategy shootingStrategy;

        protected CircularVectorShootingStrategy()
        {

        }

        protected CircularVectorShootingStrategy(VectorShootingStrategy shootingStrategy)
        {

        }
    }
}
