using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStrategy
{
    public abstract class NonCircularVectorShootingStrategy<T, U> : NonCircularShootingStrategy<T, U>
    {
        protected VectorShootingStrategy shootingStrategy;

        protected NonCircularVectorShootingStrategy()
        {

        }

        protected NonCircularVectorShootingStrategy(VectorShootingStrategy shootingStrategy)
        {

        }
    }
}
