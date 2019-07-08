using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recognition;
using MusicPattern;

namespace Secondary_Queen
{
    public class SecondaryRhythmPattern : SecondaryPattern, IGamePattern<Rhythm>
    {


        private RhythmPattern rhythmPattern;

        public SecondaryRhythmPattern()
        {

        }

        public SecondaryRhythmPattern(ISecondaryMovingStrategy move, RhythmPattern rhythmPattern)
        {

        }

        public SecondaryRhythmPattern(ISecondaryShootingStrategy shoot, RhythmPattern rhythmPattern)
        {

        }

        public SecondaryRhythmPattern(ISecondaryMovingStrategy move, ISecondaryShootingStrategy shoot, RhythmPattern rhythmPattern)
        {

        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public Rhythm RetrieveCurrent()
        {
            throw new NotImplementedException();
        }

        public Rhythm RetrieveNext()
        {
            throw new NotImplementedException();
        }

        public Rhythm RetrievePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
