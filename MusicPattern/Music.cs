using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPattern
{
    public class Music
    {
        private List<Rhythm> _rhythms;
        private int _currentRhythmIndex;


        private string _musicLocation;
        private int _musicDuration;



        public Music()
        {
            _rhythms = new List<Rhythm>();

            Dictionary<int, int> structure1 = new Dictionary<int, int>();
            Dictionary<int, int> structure2 = new Dictionary<int, int>();
            Dictionary<int, int> structure3 = new Dictionary<int, int>();
            Dictionary<int, int> structure4 = new Dictionary<int, int>();

            Dictionary<int, int> structure5 = new Dictionary<int, int>();
            Dictionary<int, int> structure6 = new Dictionary<int, int>();

            List<bool> ignoreClaps = new List<bool>();

            int count = 0;
            int sum = 0;

            while (sum < 224000)
            {
                sum = 6 * 1000 + count * 1300;

                if (count % 4 == 0)
                {
                    structure1.Add(sum, 3);
                    structure2.Add(sum, 3);
                    structure3.Add(sum, 3);

                    structure4.Add(sum, 2);
                    structure5.Add(sum, 2);


                    structure6.Add(sum, 1);

                }
                else
                {
                    structure1.Add(sum, 1);
                    structure2.Add(sum, 2);
                    structure3.Add(sum, 1);

                    structure4.Add(sum, 3);
                    structure5.Add(sum, 1);

                    structure6.Add(sum, 3);
                }
                count++;
                ignoreClaps.Add(false);
            }

            _rhythms.Add(new Rhythm(structure1, ignoreClaps));
            _rhythms.Add(new Rhythm(structure2, ignoreClaps));
            _rhythms.Add(new Rhythm(structure3, ignoreClaps));
            _rhythms.Add(new Rhythm(structure4, ignoreClaps));


            _currentRhythmIndex = 0;
            _musicDuration = 4 * 60 * 1000 + 5 * 1000;
            _musicLocation = "C:\\Users\\Test\\Desktop\\The Queen Music\\Neyo\\Ne - Yo\\Ne-Yo Ft. Sarah Connor - Sexual Healing";

        }

        public Music(int _musicDuration, List<Rhythm> _rhythms, int _currentRhythmIndex, string _musicLocation)
        {
            this._rhythms = _rhythms;
            this._currentRhythmIndex = _currentRhythmIndex;

            this._musicLocation = _musicLocation;
            this._musicDuration = _musicDuration;
        }

        public Music(int _musicDuration, List<Rhythm> _rhythms, int _currentRhythmIndex, string _musicLocation, bool _repeatMusic)
        : this(_musicDuration, _rhythms, _currentRhythmIndex, _musicLocation)
        {

        }


        public List<Rhythm> Rhythms { get; set; }

        public int CurrentRhythmIndex { get; set; }


        public string MusicLocation { get; set; }

        public int MusicDuration { get; set; }

        public void SwitchRhythm()
        {
            _currentRhythmIndex = new Random().Next(0, _rhythms.Count);
        }

        public void SetNextRhythm()
        {
            _currentRhythmIndex = (CurrentRhythmIndex + 1) % _rhythms.Count;
        }

        public void SetPreviousRhythm()
        {
            if (CurrentRhythmIndex == 0)
                CurrentRhythmIndex = _rhythms.Count - 1;
            else
                CurrentRhythmIndex--;
        }

        public void DisplayMusic()
        {
            Console.WriteLine(ToString());
        }

        public override String ToString()
        {
            String presentation = "Music Mood(s)\t:";

            foreach (Rhythm rhythm in _rhythms)
                presentation += rhythm.ToString();

            presentation += ("Music File Location : " + _musicLocation + "\n\n");

            presentation += ("Music Duration : " + _musicDuration + " milliseconds.\n");

            return presentation;
        }

    }
}
