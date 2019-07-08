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
    public class RhythmPattern : GamePattern, IGamePattern<Rhythm>
    {
        private List<Rhythm> rhythms;
        private int currentRhythmIndex;
        private RhythmChange rhythmChange;

        public int CurrentRhythmIndex
        {
            get
            {
                return currentRhythmIndex;
            }

            set
            {
                if (value >= 0 && value < rhythms.Count)
                    currentRhythmIndex = value;
            }
        }

        public List<Rhythm> Rhythms { get; }

        public RhythmChange RhythmChange { get; set; }

        public RhythmPattern()
        {
            rhythmChange = RhythmChange.NEXT_RHYHTM_CHANGE;
            rhythms = new List<Rhythm>();

            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_ONE, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TWO, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_THREE, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_FOUR, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_FIVE, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_SIX, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_SEVEN, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_EIGHT, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_NINE, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TEN, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_ELEVEN, 60));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TWELVE, 60));


            List<bool> ignoreClaps = new List<bool>();

            for (int i = 1; i < 61; i++)
                ignoreClaps.Add(false);

            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_ONE, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TWO, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_THREE, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_FOUR, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_FIVE, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_SIX, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_SEVEN, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_EIGHT, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_NINE, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TEN, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_ELEVEN, 60, ignoreClaps));
            rhythms.Add(new Rhythm(RhythmClass.RHYTHM_TWELVE, 60, ignoreClaps));

        }

        public RhythmPattern(List<Rhythm> rhythms, List<IMovingStrategy> movingStrategies,
        List<float> multiples, List<StageChange> stageChanges, bool isPrimaryPattern)
        : this(rhythms, movingStrategies, null, multiples, stageChanges, 0, -1, 0, isPrimaryPattern)
        {

        }


        public RhythmPattern(List<Rhythm> rhythms, List<IMovingStrategy> movingStrategies,
        List<IShootingStrategy> shootingStrategies, List<float> multiples,
        List<StageChange> stageChanges, int movingStrategyIndex,
        int shootingStrateyIndex, int multiplesIndex, bool isPrimaryPattern)
        : base(movingStrategies, shootingStrategies, multiples, stageChanges,
        movingStrategyIndex, shootingStrateyIndex, multiplesIndex, isPrimaryPattern)
        {
            this.rhythms = rhythms;
            rhythmChange = RhythmChange.NEXT_RHYHTM_CHANGE;
        }

        public Rhythm RetrieveNext()
        {
            if (rhythms.Count > 0)
                if (currentRhythmIndex < rhythms.Count - 1)
                    return rhythms[currentRhythmIndex + 1];
                else
                {
                    return rhythms[0];
                }
            else
                return null;
        }

        public void Remove(int index)
        {
            rhythms.Remove(rhythms[index]);
        }

        public Rhythm RetrievePrevious()
        {
            if (rhythms.Count > 0)
                if (currentRhythmIndex > 0)
                    return rhythms[currentRhythmIndex - 1];
                else
                {
                    return rhythms[rhythms.Count - 1];
                }
            else
                return null;
        }

        public Rhythm RetrieveCurrent()
        {
            return rhythms[currentRhythmIndex];
        }



        private void NextRhythmIndex()
        {
            if (rhythms.Count > 0)
                if (currentRhythmIndex < rhythms.Count - 1)
                    currentRhythmIndex++;
                else
                {
                    currentRhythmIndex = 0;
                }

        }

        private void PreviousRhythmIndex()
        {
            if (rhythms.Count > 0)
            {
                if (currentRhythmIndex > 0)
                    currentRhythmIndex--;
                else
                    currentRhythmIndex = rhythms.Count - 1;
            }
        }

        private void RandomizeRhythmIndex()
        {
            currentRhythmIndex = new Random().Next(0, rhythms.Count);
        }

        public override void ChangeLevel(StageChange stageChange)
        {
            if (stageChange == StageChange.CHANGE_RHYTHM)
            {
                if (rhythmChange == RhythmChange.NEXT_RHYHTM_CHANGE)
                    NextRhythmIndex();
                else if (rhythmChange == RhythmChange.PREVIOUS_RHYTHM_CHANGE)
                    PreviousRhythmIndex();
                else
                    RandomizeRhythmIndex();

            }

        }
    }
}
