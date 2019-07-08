using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;
using MusicPattern;

namespace Primary_Queen
{
    public class PrimaryQueen : Queen
    {
        private IPrimaryMovingStrategy primaryMovingStrategy;


        public PrimaryQueen()
        {

        }

        public PrimaryQueen(IPrimaryMovingStrategy primaryMovingStrategy)
        {

        }

        public PrimaryQueen(IPrimaryMovingStrategy primaryMovingStrategy, Rhythm rhythm)
        {

        }
    }
}
