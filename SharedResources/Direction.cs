
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;

namespace SharedResources
{
    /* The class contains fields and methods that a common in 
     CircularDirection and NonCircularDirection.*/
    public class Direction<U> : Helper<U>
    {
        private ISharedDirection sharedDirection;
        private float directionComponentLength;

        public ISharedDirection SharedDirection
        {
            get { return sharedDirection; }
            set
            {
                if (value.Divisor != 0 &&
                value.GetDirectionLength() % value.Divisor == 0
                && value.Divisor < value.GetDirectionLength())
                {
                    sharedDirection = value;
                    //Fill();
                }
            }

        }
        public float DirectionComponentLength { get; set; }


        public Direction()
        : base()
        {

        }

        public Direction(Point startingPoint, int direction,
        ISharedDirection sharedDirection, List<float> speedList, float speed)
        : base(startingPoint, direction, speedList, speed)
        {

            this.sharedDirection = sharedDirection;
            directionComponentLength = DetermineDirectionComponentLength(this.sharedDirection);
        }


        

    }
}

