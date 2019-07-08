using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;
using MusicPattern;
using BuildingBlocks;
using Pieces;
using SharedResources;
using MovingStrategy;

namespace Secondary_Queen
{
    public class SecondaryGame : Game
    {
        public SecondaryGame()
        {

        }

        protected SecondaryGame(Dictionary<int, float> _markAllocation, List<Player> _players, Secondary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, CartesianPlane cartesianPlane, Rhythm currentRhythm)
        {

        }

        protected SecondaryGame(Dictionary<int, float> _markAllocation, List<Player> _players, Secondary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, CartesianPlane cartesianPlane, Music currentMusic)
        {

        }

        protected SecondaryGame(Dictionary<int, float> _markAllocation, List<Player> _players, Secondary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, CartesianPlane cartesianPlane, Rhythm currentRhythm, Music currentMusic)
        {

        }


        protected Secondary_Direction RequestQueenDirection(int thinkingTime)
        {
            return Secondary_Direction.Direction_One;
        }

        protected Secondary_King_Direction RequestKingDirection(int thinkingTime)
        {

            return Secondary_King_Direction.FACING_FRONT;
        }

        protected HashSet<Secondary_Direction> RequestQueenVectors(int thinkingTime)
        {

            throw new NotImplementedException();
        }





        protected ILetter RequestQueenLetter(int thinkingTime)
        {
            ILetter playerAnswer = null;

            return playerAnswer;
        }

        protected R2Function RequestQueenFunction(int thinkingTime)
        {
            R2Function playerAnswer = null;

            return playerAnswer;
        }

        public void RetrieveChoosenShootingStrategy()
        {

        }
    }
}
