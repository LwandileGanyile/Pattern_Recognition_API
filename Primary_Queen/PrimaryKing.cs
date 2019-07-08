using MovingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;

namespace Primary_Queen
{
    public class PrimaryKing : King
    {
        private Primary_King_Direction kingDirection;

        public Primary_King_Direction KingDirection { get; set; }

        public PrimaryKing()
        {

        }

        public PrimaryKing(Primary_King_Direction kingDirection)
        {
            this.kingDirection = kingDirection;
        }

    }
}
