using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStrategy
{
    public abstract class CircularFunctionShootingStrategy<T, U> : CircularShootingStrategy<T, U>
    {
        protected FunctionShootingStrategy shootingStrategy;

        protected CircularFunctionShootingStrategy()
        {

        }

        protected CircularFunctionShootingStrategy(FunctionShootingStrategy shootingStrategy)
        {

        }
    }
}
