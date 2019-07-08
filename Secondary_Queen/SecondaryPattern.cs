using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Secondary_Queen
{
    public class SecondaryPattern
    {
        protected ISecondaryMovingStrategy movingStrategy;
        protected ISecondaryShootingStrategy shootingStrategy;

        protected SecondaryPattern()
        {

        }

        protected SecondaryPattern(ISecondaryMovingStrategy movingStrategy)
        {

        }

        protected SecondaryPattern(ISecondaryShootingStrategy shootingStrategy)
        {

        }

        protected SecondaryPattern(ISecondaryMovingStrategy movingStrategy, ISecondaryShootingStrategy shootingStrategy)
        {

        }


    }
}
