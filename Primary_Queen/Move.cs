using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class Move<U>
    {
        protected IMove movingStrategy;

        public IMove IMovingStrategy { get { return movingStrategy; } set { if (value != null) movingStrategy = value; } }

        protected Move()
        {
            movingStrategy = new FirstMove();
        }

        protected Move(IMove movingStrategy)
        {
            this.movingStrategy = movingStrategy;
        }

        protected void FillMoveStrategy()
        {
            movingStrategy.FillMove();
        }
    }
}
