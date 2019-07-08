using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;

namespace Interaction
{
    public abstract class King : Agent
    {

        protected int currentStep;
        protected HashSet<KingStep> steps;


        public King()
        {

        }

        public King(KingStep _kingStep)
        {

        }

        public King(KingStep _kingStep, Rhythm rhythm)
        {

        }

        public KingStep KingStep { get; set; }

        public override void Resume()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
