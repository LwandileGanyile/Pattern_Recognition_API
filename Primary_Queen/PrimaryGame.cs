using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;
using MusicPattern;
using MovingStrategy;

namespace Primary_Queen
{
    public class PrimaryGame : Game
    {

        protected List<Primary_Trace_Type> _traceTypes;

        public Primary_Trace_Type TraceType { get; set; }

        public PrimaryGame()
        {

        }

        protected PrimaryGame(Dictionary<int, float> _markAllocation, List<PrimaryPlayer> _players, Primary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, NumberLine numberLine, Rhythm currentRhythm)
        {

        }

        protected PrimaryGame(Dictionary<int, float> _markAllocation, List<PrimaryPlayer> _players, Primary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, NumberLine numberLine, Music currentMusic)
        {

        }

        protected PrimaryGame(Dictionary<int, float> _markAllocation, List<PrimaryPlayer> _players, Primary_Trace_Type _traceType,
        Dictionary<int, int> _switchingTimes, NumberLine numberLine, Rhythm currentRhythm, Music currentMusic)
        {

        }


        protected Primary_Direction RequestQueenDirection(int thinkingTime)
        {
            return Primary_Direction.RIGHT;
        }

        protected Primary_King_Direction RequestKingDirection(int thinkingTime)
        {

            return Primary_King_Direction.FACING_FRONT;
        }

        protected bool IsQuestionAllowed(Primary_Trace_Type traceType)
        {
            return true;
        }

        public void AddTraceType(Primary_Trace_Type traceType)
        {

        }

        public void RemoveTraceType(Primary_Trace_Type traceType)
        {

        }

    }
}
