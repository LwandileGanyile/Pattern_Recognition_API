using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recognition;
using MusicPattern;


namespace Secondary_Queen
{
    public class SecondaryMusicPattern : SecondaryPattern, IGamePattern<Music>
    {

        private Recognition.MusicPattern musicPattern;

        public SecondaryMusicPattern()
        {

        }

        public SecondaryMusicPattern(ISecondaryMovingStrategy move, Recognition.MusicPattern musicPattern)
        {

        }

        public SecondaryMusicPattern(ISecondaryShootingStrategy shoot, Recognition.MusicPattern musicPattern)
        {

        }

        public SecondaryMusicPattern(ISecondaryMovingStrategy move, ISecondaryShootingStrategy shoot, Recognition.MusicPattern musicPattern)
        {

        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public Music RetrieveCurrent()
        {
            throw new NotImplementedException();
        }

        public Music RetrieveNext()
        {
            throw new NotImplementedException();
        }

        public Music RetrievePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
