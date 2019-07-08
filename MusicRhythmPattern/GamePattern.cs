using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingStrategy;
using ShootingStrategy;

namespace Recognition
{
    public abstract class GamePattern
    {

        protected List<IMovingStrategy> movingStrategies;
        protected List<IShootingStrategy> shootingStrategies;
        protected List<float> multiples;
        protected List<StageChange> stageChanges;

        protected int movingStrategyIndex;
        protected int shootingStrategyIndex;
        protected int multiplesIndex;

        private int stageChangeIndex = 0;

        protected bool isPrimaryPattern;

        protected MovingStrategyChange movingStrategyChange;
        protected ShootingStrategyChange shootingStrategyChange;
        protected MultipleChange multipleChange;



        public List<IMovingStrategy> MovingStrategies { get; }
        public List<IShootingStrategy> ShootingStrategies { get; }
        public List<float> Multiples { get; }
        public List<StageChange> StageChanges { get; }

        public bool IsPrimaryPattern { get; }

        public MovingStrategyChange MovingStrategyChange { get; set; }
        public ShootingStrategyChange ShootingStrategyChange { get; set; }

        public MultipleChange MultipleChange { get; set; }

        public int MovingStrategyIndex { get; }
        public int ShootingStrategyIndex { get; }
        public int MultiplesIndex { get; }

        protected GamePattern()
        {
            InitializeChange();
        }

        protected GamePattern(List<IMovingStrategy> movingStrategies,
        List<float> multiples, List<StageChange> stageChanges, bool isPrimaryPattern)
        : this(movingStrategies, null, multiples, stageChanges, 0, -1, 0, isPrimaryPattern)
        {

        }

        protected GamePattern(List<IMovingStrategy> movingStrategies,
        List<IShootingStrategy> shootingStrategies, List<float> multiples,
        List<StageChange> stageChanges, bool isPrimaryPattern)
        : this(movingStrategies, shootingStrategies, multiples, stageChanges, 0, 0, 0, isPrimaryPattern)
        {

        }

        protected GamePattern(List<IMovingStrategy> movingStrategies,
        List<IShootingStrategy> shootingStrategies, List<float> multiples,
        List<StageChange> stageChanges, int movingStrategyIndex,
        int shootingStrategyIndex, int multiplesIndex, bool isPrimaryPattern)
        {
            this.movingStrategies = movingStrategies;
            this.shootingStrategies = shootingStrategies;
            this.multiples = multiples;
            this.stageChanges = stageChanges;

            this.isPrimaryPattern = isPrimaryPattern;

            this.movingStrategyIndex = movingStrategyIndex;
            this.shootingStrategyIndex = shootingStrategyIndex;
            this.multiplesIndex = multiplesIndex;

            InitializeChange();
        }

        private void InitializeChange()
        {
            movingStrategyChange = MovingStrategyChange.NEXT_MOVING_STRATEGY_CHANGE;
            shootingStrategyChange = ShootingStrategyChange.NEXT_SHOOTING_STRATEGY_CHANGE;
            multipleChange = MultipleChange.NEXT_MULTIPLE_CHANGE;
        }

        public void ChangeLevel()
        {
            switch (stageChanges[stageChangeIndex])
            {
                case StageChange.CHANGE_MOVING_STRATEGY:
                    if (movingStrategyChange == MovingStrategyChange.NEXT_MOVING_STRATEGY_CHANGE)
                        NextMoveIndex();
                    else if (movingStrategyChange == MovingStrategyChange.PREVIOUS_MOVING_STRATEGY_CHANGE)
                        PreviousMoveIndex();
                    else
                        RandomizeMoveIndex();
                    break;
                case StageChange.CHANGE_MULTIPLE:
                    if (multipleChange == MultipleChange.NEXT_MULTIPLE_CHANGE)
                        NextMultipleIndex();
                    else if (multipleChange == MultipleChange.PREVIOUS_MULTIPLE_CHANGE)
                        PreviousMultipleIndex();
                    else
                        RandomizeMultipleIndex();
                    break;

                case StageChange.CHANGE_ROTATION_OR_REPEATATION:
                    break;
                case StageChange.CHANGE_SHOOTING_STRATEGY:
                    if (shootingStrategyChange == ShootingStrategyChange.NEXT_SHOOTING_STRATEGY_CHANGE)
                        NextShootIndex();
                    else if (shootingStrategyChange == ShootingStrategyChange.PREVIOUS_SHOOTING_STRATEGY_CHANGE)
                        NextShootIndex();
                    else
                        RandomizeShootIndex();
                    break;

            }

            ChangeLevel(stageChanges[stageChangeIndex]);

        }

        public abstract void ChangeLevel(StageChange stageChange);

        private void NextMoveIndex()
        {
            if (movingStrategies.Count > 0)
                if (movingStrategyIndex < movingStrategies.Count - 1)
                    movingStrategyIndex++;
                else
                {
                    movingStrategyIndex = 0;
                }
        }

        private void PreviousMoveIndex()
        {
            if (movingStrategies.Count > 0)
            {
                if (movingStrategyIndex > 0)
                    movingStrategyIndex--;
                else
                    movingStrategyIndex = movingStrategies.Count - 1;
            }
        }

        private void RandomizeMoveIndex()
        {
            movingStrategyIndex = new Random().Next(0, movingStrategies.Count);
        }



        private void NextShootIndex()
        {
            if (shootingStrategies.Count > 0)
                if (shootingStrategyIndex < shootingStrategies.Count - 1)
                    shootingStrategyIndex++;
                else
                {
                    shootingStrategyIndex = 0;
                }
        }

        private void PreviousShootIndex()
        {
            if (shootingStrategies.Count > 0)
            {
                if (movingStrategyIndex > 0)
                    shootingStrategyIndex--;
                else
                    shootingStrategyIndex = shootingStrategies.Count - 1;
            }
        }

        private void RandomizeShootIndex()
        {
            shootingStrategyIndex = new Random().Next(0, shootingStrategies.Count);
        }



        private void NextMultipleIndex()
        {
            if (multiples.Count > 0)
                if (shootingStrategyIndex < multiples.Count - 1)
                    multiplesIndex++;
                else
                {
                    multiplesIndex = 0;
                }
        }

        private void PreviousMultipleIndex()
        {
            if (multiples.Count > 0)
            {
                if (movingStrategyIndex > 0)
                    multiplesIndex--;
                else
                    multiplesIndex = multiples.Count - 1;
            }
        }

        private void RandomizeMultipleIndex()
        {
            multiplesIndex = new Random().Next(0, multiples.Count);
        }






    }
}
