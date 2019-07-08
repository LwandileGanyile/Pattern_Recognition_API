using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using Game_Defination;

namespace Interaction
{
    public abstract class Agent : IUpdate, IAgent
    {
        private Rhythm rhythm;

        protected Agent()
        {

        }

        protected Agent(Rhythm rhythm)
        {

        }

        public Rhythm Rhythm
        {
            get; set;
        }

        public abstract void Resume();
        public abstract void Stop();
        public abstract void Update();
    }
}
