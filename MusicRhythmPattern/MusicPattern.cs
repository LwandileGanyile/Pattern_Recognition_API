using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using MovingStrategy;
using ShootingStrategy;

namespace Recognition
{
    public class MusicPattern : GamePattern, IGamePattern<Music>
    {
        private List<Music> music;
        private int currentMusicIndex;
        private MusicChange musicChange;


        public int CurrentMusicIndex
        {
            get
            {
                return currentMusicIndex;
            }

            set
            {
                if (value >= 0 && value < music.Count)
                    currentMusicIndex = value;
            }
        }

        public MusicChange MusicChange { get; set; }

        public MusicPattern()
        : base()
        {
            music = new List<Music>();
            music.Add(new Music());
            musicChange = MusicChange.NEXT_MUSIC_CHANGE;

            currentMusicIndex = 0;
        }


        public MusicPattern(List<Music> music, List<IMovingStrategy> movingStrategies,
        List<float> multiples, List<StageChange> stageChanges, bool isPrimaryPattern)
        : this(music, movingStrategies, null, multiples, stageChanges, 0, -1, 0, isPrimaryPattern)
        {

        }


        public MusicPattern(List<Music> music, List<IMovingStrategy> movingStrategies,
        List<IShootingStrategy> shootingStrategies, List<float> multiples,
        List<StageChange> stageChanges, int movingStrategyIndex,
        int shootingStrateyIndex, int multiplesIndex, bool isPrimaryPattern)
        : base(movingStrategies, shootingStrategies, multiples, stageChanges,
        movingStrategyIndex, shootingStrateyIndex, multiplesIndex, isPrimaryPattern)
        {
            this.music = music;
            musicChange = MusicChange.NEXT_MUSIC_CHANGE;
        }

        public void Remove(int index)
        {
            music.Remove(music[index]);
        }

        public Music RetrieveCurrent()
        {
            return music[currentMusicIndex];
        }

        public Music RetrieveNext()
        {
            if (music.Count > 0)
                if (currentMusicIndex < music.Count - 1)
                    return music[currentMusicIndex + 1];
                else
                {
                    return music[0];
                }
            else
                return null;
        }

        public Music RetrievePrevious()
        {
            if (music.Count > 0)
                if (currentMusicIndex > 0)
                    return music[currentMusicIndex - 1];
                else
                {
                    return music[music.Count - 1];
                }
            else
                return null;
        }




        private void NextMusicIndex()
        {
            if (music.Count > 0)
                if (currentMusicIndex < music.Count - 1)
                    currentMusicIndex++;
                else
                {
                    currentMusicIndex = 0;
                }
        }

        private void PreviousMusicIndex()
        {
            if (music.Count > 0)
            {
                if (currentMusicIndex > 0)
                    currentMusicIndex--;
                else
                    currentMusicIndex = music.Count - 1;
            }
        }

        private void RandomizeMusicIndex()
        {
            currentMusicIndex = new Random().Next(0, music.Count);
        }

        public override void ChangeLevel(StageChange stageChange)
        {
            if (stageChange == StageChange.CHANGE_MUSIC)
            {
                if (musicChange == MusicChange.NEXT_MUSIC_CHANGE)
                    NextMusicIndex();
                else if (musicChange == MusicChange.PREVIOUS_MUSIC_CHANGE)
                    PreviousMusicIndex();
                else
                    RandomizeMusicIndex();

            }
        }
    }
}
