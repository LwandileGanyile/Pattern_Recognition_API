using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStrategy
{
    public abstract class NonCircularFunctionShootingStrategy<T, U> : NonCircularShootingStrategy<T, U>
    {
        protected FunctionShootingStrategy shootingStrategy;

        protected NonCircularFunctionShootingStrategy()
        {

        }

        protected NonCircularFunctionShootingStrategy(FunctionShootingStrategy shootingStrategy)
        {

        }
    }
}
