using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recognition;
using MusicPattern;


namespace Primary_Queen
{
    public class PrimaryRhythmPattern : PrimaryPattern, IGamePattern<Rhythm>
    {
        private RhythmPattern rhythmPattern;

        public PrimaryRhythmPattern()
        {

        }

        public PrimaryRhythmPattern(IPrimaryMovingStrategy movingStrategy, RhythmPattern rhythmPattern)
        {

        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }


        Rhythm IGamePattern<Rhythm>.RetrieveCurrent()
        {
            throw new NotImplementedException();
        }

        Rhythm IGamePattern<Rhythm>.RetrieveNext()
        {
            throw new NotImplementedException();
        }

        Rhythm IGamePattern<Rhythm>.RetrievePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
