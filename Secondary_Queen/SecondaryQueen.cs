using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;
using MusicPattern;

namespace Secondary_Queen
{
    public class SecondaryQueen : Queen
    {
        private ISecondaryMovingStrategy secondaryMovingStrategy;
        private ISecondaryShootingStrategy secondaryShootingStrategy;


        public SecondaryQueen()
        {

        }

        public SecondaryQueen(ISecondaryMovingStrategy secondaryMovingStrategy)
        {

        }

        public SecondaryQueen(ISecondaryShootingStrategy secondaryShootingStrategy)
        {

        }

        public SecondaryQueen(ISecondaryMovingStrategy secondaryMovingStrategy, ISecondaryShootingStrategy secondaryShootingStrategy)
        {

        }

        public SecondaryQueen(ISecondaryMovingStrategy secondaryMovingStrategy, Rhythm rhythm)
        {

        }

        public SecondaryQueen(ISecondaryMovingStrategy secondaryMovingStrategy, Rhythm rhythm, ISecondaryShootingStrategy secondaryShootingStrategy)
        {

        }
    }
}
