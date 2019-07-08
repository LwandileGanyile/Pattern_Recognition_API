using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;
using MovingStrategy;
using Pieces;

namespace Primary_Queen
{
    // All class members that are duplicated in both the CPrimaryMovingStrategy and 
    // NCPrimaryMovingStrategy.
    // U - is either R1CircularDirection or R1NonCircularDirection.
    public class MovingStrategyHelper<U> : ICloneable
    {
        private MyLinkedList<U> list;

        public MovingStrategyHelper()
        {

        }

        public void Add(U direction) { list.Add(direction); }
        public void RemoveFirst() { list.RemoveFirst(); }
        public void RemoveLast() { list.RemoveLast(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }


    }
}
